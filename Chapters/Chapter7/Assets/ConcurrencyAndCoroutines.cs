﻿/*
 * Chapter 7.18 Concurrency And Coroutines
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Collections;

using UnityEngine;

public class ConcurrencyAndCoroutines : MonoBehaviour
{

    /*
     * Section 7.18.1 Yield
     */

    private bool UsedFillupObjects;
    void FillUpObjects()
    {
        if (!UsedFillupObjects)
        {
            UsedFillupObjects = true;
            int numObjects = 50000;
            GameObject[] lotsOfObjects = new GameObject[numObjects];
            for (int i = 0; i < numObjects; i++)
            {
                GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
                g.name = i.ToString() + "_Cube";
                g.transform.position = new Vector3()
                {
                    x = UnityEngine.Random.Range(-1000, 1000),
                    y = UnityEngine.Random.Range(-1000, 1000),
                    z = UnityEngine.Random.Range(-1000, 1000)
                };
                g.transform.localScale = new Vector3()
                {
                    x = UnityEngine.Random.Range(1, 10),
                    y = UnityEngine.Random.Range(1, 10),
                    z = UnityEngine.Random.Range(1, 10)
                };
                lotsOfObjects[i] = g;
            }
            Debug.Log("Finished at:" + Time.fixedUnscaledTime);
        }
    }

    private bool UsedFillWithYield;
    IEnumerator FillWithYield()
    {
        if (!UsedFillWithYield)
        {
            UsedFillWithYield = true;
            int numObjects = 1000;
            GameObject[] lotsOfObjects = new GameObject[numObjects];
            for (int i = 0; i < numObjects; i++)
            {
                GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
                g.name = i.ToString() + "_Cube";
                g.transform.position = new Vector3()
                {
                    x = UnityEngine.Random.Range(-1000, 1000),
                    y = UnityEngine.Random.Range(-1000, 1000),
                    z = UnityEngine.Random.Range(-1000, 1000)
                };
                g.transform.localScale = new Vector3()
                {
                    x = UnityEngine.Random.Range(1, 10),
                    y = UnityEngine.Random.Range(1, 10),
                    z = UnityEngine.Random.Range(1, 10)
                };
                lotsOfObjects[i] = g;
                /* Yield goes after an interation  */
                /* through the for loop.           */
                yield return null;
            }
            Debug.Log("Finished at:" + Time.fixedUnscaledTime);
        }
    }

    /*
     * Section 7.18.1.1 A Basic Example
     */
    void UseDelayAStatement()
    {
        StartCoroutine(DelayAStatement());
    }     /*               ↑                    */
          /*  ┌────────────┴──────────────────┐ */
          /*  │the function and parameter list│ */
          /*  │is added as a parameter to the │ */
          /*  │StartCoroutine function        │ */
          /*  └────────────┬──────────────────┘ */
          /*               ↑                    */
    IEnumerator DelayAStatement()
    {
        Debug.Log("DelayAStatement Started at:" + Time.fixedTime);
        yield return new WaitForSeconds(3.0f);
        Debug.Log("DelayAStatement Finished at:" + Time.fixedTime);
    }

    void UseMultipleDelayAStatements()
    {
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(MultiDelayAStatement(i));
        }
    }

    IEnumerator MultiDelayAStatement(int i)
    {
        Debug.Log(i + ") DelayAStatement Started at:" + Time.fixedTime);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(i + ") DelayAStatement Finished at:" + Time.fixedTime);
    }

    /*
     * 7.18.2 Setting Up Timers
     */

    void TheAction()                  /*  ┌─────────────┐    */
    {                                 /*  │this function│    */
        Debug.Log("Doing the thing!");/*  │gets assigned│    */
    }                                 /*  │as a variable│    */
                                      /*  └─────────────┘    */
    void UseTimedAction()             /*    │                */
    {                                 /*    ↓                */
        StartCoroutine(TimedAction(3f, TheAction));/*        */
    }                                 /*    ↓                */
                                      /*    └────────────┐   */
    private IEnumerator TimedAction(float time, Action action)
    {                                         /*         ↓   */
        yield return new WaitForSeconds(time);/*         │   */
        action?.Invoke();/* ←────────────────────────────┘   */
    }                    /* then gets called here after wait */

    /*
     * Using Lerp with Coroutines
     * we have two parts here, a delegate
     * and the IEnumerator ValueUpdater
     */
    delegate void UpdateValue(float value);

    IEnumerator ValueUpdater(float start, float finish, float time, UpdateValue valueUpdated)
    {
        /* starting at 0     */
        /* we increment this */
        /* toward 1          */
        float t = 0;
        while (t < 1)
        {
            /* Lerp goes from start value to     */
            /* the finish value using a range    */
            /* from 0 to 1                       */
            float v = Mathf.Lerp(start, finish, t);
            
            /* increment the t value from        */
            /* 0 to 1                            */
            t += Time.deltaTime / time;
            
            /* call the event assigned           */
            valueUpdated?.Invoke(v);

            /* wait till the end of the frame    */
            /* before starting the while loop    */
            /* again.                            */
            yield return new WaitForEndOfFrame();
        }
    }

    /* this function is delegated to get updates */
    void GetUpdatedValue(float f)
    {
        /* this could lerp any value   */
        /*  in the given span of time! */
        Debug.Log("Lerp Updated:" + f);
    }

    void UseLerpAction()
    {
        /* starting at a value of 3, we go to 7 in 3 seconds */
        StartCoroutine(ValueUpdater(6f, 9f, 3f, GetUpdatedValue));

        Debug.Log(Mathf.Lerp(6f, 9f, 0.5f));
        // 7.5
    }

    /*
     * 7.18.4 Arrays of Delegates
     * rather than send one thing to the coroutine
     * we can send multiple delegate functions
     */
    
    delegate float ThingsToDo(string thing);
    IEnumerator DoingTheThings(ThingsToDo[] things)
    {
        Debug.Log("Doing the things:" + Time.fixedTime);
        
        foreach (ThingsToDo thing in things)
        {
            float nextTime = thing.Invoke("Doing the thing.");
            yield return new WaitForSeconds(nextTime);
        }

        Debug.Log("Things done:" + Time.fixedTime);
    }

    float FirstThing(string thing)
    {
        Debug.Log("First thing is:" + thing + " at " + Time.fixedTime);
        return 3f;
    }

    float SecondThing(string thing)
    {
        Debug.Log("Second thing is:" + thing + " at " + Time.fixedTime);
        return 3f;
    }

    void UseThingsToDo()
    {
        ThingsToDo[] someThings = new ThingsToDo[2] { FirstThing, SecondThing };
        StartCoroutine(DoingTheThings(someThings));
    }

    /*
     * Section 7.18.4 Stopping a Coroutine
     */
    
    void UseStopAllCoroutines()
    {
        StartCoroutine(GetsInterrupted());
        StartCoroutine(StopsAllCoRoutines());
    }
    
    IEnumerator GetsInterrupted()
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(10f);

        Debug.Log("Stopped.");
        // never gets called.
    }

    IEnumerator StopsAllCoRoutines()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Stopping all coroutines");
        StopAllCoroutines();
    }
    
    /*
     * Stopping a specific coroutine
     */

    IEnumerator Counter()
    {
        int i = 0;
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Counting:" + i++);
        }
    }

    void UseStopCoroutine()
    {
        IEnumerator counter = Counter();
        /*             ↓            create and              */
        /*             └───┐        store the Counter()     */
        /*                 ↓        as a variable and pass  */
        StartCoroutine(counter);/*  the variable to be      */
        /*                 ↓        used to stop it         */
        /*                 └───────────┐                    */
        /*                             ↓                    */
        StartCoroutine(StopCounter(counter));
    }


    IEnumerator StopCounter(IEnumerator counter)
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Stopping Coroutine Counter()");
        StopCoroutine(counter);
    }

    /*
     * Check class variables to continue
     */

    bool ContinueToDoTheThing = true;
    IEnumerator ChecksToKeepGoing()
    {
        Debug.Log("Starting to do the thing.");
        int i = 0;
        while (ContinueToDoTheThing)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Continuing to do the thing " + i++ + " times.");
        }
        Debug.Log("Finished the things.");
    }

    IEnumerator StopDoingTheThing()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Setting ContinueToDoTheThing to false");
        ContinueToDoTheThing = false;
    }

    void UseExternalInterrupt()
    {
        StartCoroutine(ChecksToKeepGoing());
        StartCoroutine(StopDoingTheThing());
    }


    private void Start()
    {
        /*
         * Section 7.18.1 Yield 
         */
        //Debug.Log("Started at:" + Time.fixedUnscaledTime);

        /* uncomment the line above along with the section
         * in the Update() function below to observe
         * FillUpObjects as either a single function or
         * a coroutine.
         */

        /*
         * Section 7.18.1.1 A Basic Example
         */
        UseDelayAStatement();
        //UseMultipleDelayAStatements();
        /* Uncomment one of the lines above to observe
         * how each statement works
         */

        /*
         * Section 7.18.2 Setting Up Timers
         */
        //UseTimedAction();
        //UseLerpAction();

        /*
         * Section 7.18.3 Arrays of Delegates
         */
        //UseThingsToDo();

        /*
         * Section 7.18.4 Stopping a Coroutine
         */
        //UseStopAllCoroutines();
        //UseStopCoroutine();
        //UseExternalInterrupt();
    }

    int count;
    private bool KeepRepeating;

    void Update()
    {
        /*
         * Section 7.18.1 Yield 
         */
        //FillUpObjects();
        //StartCoroutine(FillWithYield());
        //Debug.Log(count++);
        
        /* Uncomment the FillUpObjects
         * or the start coroutine
         * StartCoroutine(FillWithYield());
         * to observe the difference between
         * the two functions.
         */
    }
}
