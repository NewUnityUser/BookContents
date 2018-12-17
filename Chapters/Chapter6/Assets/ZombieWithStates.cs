﻿/*
 * Chapter 6.16.2 Zombie State Machine
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class ZombieWithStates : MonoBehaviour
{
    public enum MovementStates
    {
        Idleing,
        Wandering,
        Looking,
        Chasing,
        Feeding
    }
    public MovementStates MovementState;
    public float StateTimer;

    Quaternion targetRotation;

    void Update()
    {
        /*
         * Section 6.16.3 Just For Zombies
         */

        HumanWithStates closestHuman = null;
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        float closest = Mathf.Infinity;
        Vector3 direction = Vector3.zero;
        foreach (GameObject go in allGameObjects)
        {
            HumanWithStates human = go.GetComponent<HumanWithStates>();
            if (human != null)
            {
                float distance = (go.transform.position - transform.position).magnitude;
                //check if it's a zombie
                if (distance < closest)
                {
                    closestHuman = human;
                    direction = go.transform.position - transform.position;
                    closest = distance;
                }
            }
        }

        /*
         * Section 6.16.2 Zombie State Machine
         */
        // Jump to specific label for updates
        switch (MovementState)
        {
            case MovementStates.Idleing: goto Idle;
            case MovementStates.Wandering: goto Wander;
            case MovementStates.Looking: goto Look;
            case MovementStates.Chasing: goto Chase;
            case MovementStates.Feeding: goto Feed;
        }

        // return here to update timers.
        UpdateTimer:
        if (Time.time > StateTimer)
        {
            StateTimer = Time.time + Random.Range(3.0f, 7.0f);
            switch (MovementState)
            {
                case MovementStates.Idleing:
                    switch (Random.Range(0, 3))
                    {
                        case 0: MovementState = MovementStates.Idleing;
                            break;
                        case 1:MovementState = MovementStates.Looking;
                            break;
                        case 2:MovementState = MovementStates.Wandering;
                            break;
                    }
                    break;
                case MovementStates.Wandering:
                case MovementStates.Looking:
                case MovementStates.Chasing:
                case MovementStates.Feeding:
                    MovementState = MovementStates.Idleing;
                    break;
            }
        }
        return;// escape from Update()

        Idle:
        Debug.Log("Idle");
        goto UpdateTimer;

        Look:
        Debug.Log("Look");
        {
            /*
             * Section 6.16.2 Zombie State Machine continued...
             */
            
            // update rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5f);
            
            // checking if we're facing our target direction
            float angle = Quaternion.Angle(transform.rotation, targetRotation);
            if (angle < 0.1f || angle == 180)
            {
                Vector3 dir = new Vector3()
                {
                    x = Random.Range(-1f, 1f),
                    y = 0,
                    z = Random.Range(-1f, 1f)
                };
                targetRotation = Quaternion.LookRotation(dir, transform.up);
            }

            /*
             * Section 6.16.3 This is a Reference to Yourself
             */

            if (this.GetType() == typeof(HumanWithStates))
                goto UpdateTimer;
            /*
             * Section 6.16.4 Just for Zombies
             */
            if (closest < 5)
            {
                targetRotation = Quaternion.LookRotation(direction, transform.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5f);
                MovementState = MovementStates.Chasing;
            }
        }
        goto UpdateTimer;

        Wander:
        Debug.Log("Wander");
        {
            /*
             * Push the character forward to walk around while lookinmg
             */
            transform.position += transform.forward * 0.01f;
            
        }
        goto Look;

        Chase:
        Debug.Log("Chase");
        {
            if (closest < 0.25f)
            {
                MovementState = MovementStates.Feeding;
            }
            transform.position += transform.forward * 0.01f;
        }
        goto UpdateTimer;

        Feed:
        Debug.Log("Feed");
        {
            if (closestHuman != null && closest < 0.25f)
            {
                // convert human to zombie
                Transform zombiePrimitive = transform.Find("ZombiePrimitive");
                if (zombiePrimitive == null)
                    return;
                Destroy(closestHuman.transform.Find("HumanPrimitive").gameObject);
                GameObject newZombie = GameObject.Instantiate(zombiePrimitive.gameObject);
                newZombie.transform.parent = closestHuman.gameObject.transform;
                newZombie.transform.localPosition = Vector3.zero;
                newZombie.transform.localRotation = Quaternion.identity;
                closestHuman.gameObject.AddComponent<ZombieWithStates>();
                Destroy(closestHuman);
                return;
            }
        }
        goto UpdateTimer;
    }
}
