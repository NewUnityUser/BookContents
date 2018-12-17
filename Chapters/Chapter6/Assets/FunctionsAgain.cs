﻿/*
 * Chapter 6.10.6 Extending Namespaces
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using UnityEngine;

public class FunctionsAgain : MonoBehaviour
{
    /*
     * Section 6.11.1 Parameter Lists
     */
    int a = 0;
    void SetA(int i)
    {
        a = i;
    }

    void Start()
    {
        /*
         * Section 6.11.1 Parameter Lists
         */
        Debug.Log("a:" + a); //0
        SetA(3);
        Debug.Log("a:" + a); //3


        /* comment each function
         * to see how they operate
         * on their own
         */
        Section6_11_4();
        Section6_11_4_1();
        Section6_11_5();
    }


    /*
     * Section 6.11.2 Side Effects
     */
    int b;
    void SetBtoFive()
    {
        b = 5;
    }
    public void SetBAgain()
    {
        b = new int();
    }

    /*
     * Section 6.11.3 Multiple Arguments
     */
    int c = 0;
    void SetCtoLeftPlusRight(int left, int right)
    {
        c = left + right;
    }
    /* the parameters names 
     * are used inside of the
     * function.
     * 
     *                          ┌─────────────────────────┐
     *                          │ ① parameters going into │
     *                          │ the function            │
     *                          └─────────────┬───────────┘
     *                                   ┌────┴────┐
     *    void SetCtoLeftPlusRight(int left, int right)
     *    {         ┌────────────────────┘         │
     *              │      ┌───────────────────────┘
     *              ↓      ↓ (these names must match the parameters)
     *        c = left + right;
     *    }   ↑ ↑   └──┬───┘
     *        │ │┌─────┴────────────┐
     *        │ ││② + adds values   │
     *        │ ││  together.       │
     *        │ └┤③ they are        │
     *        │  │  assigned to:    │
     *        └──┤④ c               │
     *           └──────────────────┘
     */

    void SetAtoLeftBtoRight(int left, int right)
    {
        a = left;
        b = right;
    }

    /*
     * Section 6.11.4 Useful Parameters
     */
    void Section6_11_4()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "MrCube";
        go.transform.position = new Vector3(0, 1, 0);
        GameObject go1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "MrsCube";
        go.transform.position = new Vector3(0, 2, 0);
        GameObject go2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "MissCube";
        go.transform.position = new Vector3(0, 3, 0);
        GameObject go3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "CubeJr";
        go.transform.position = new Vector3(0, 4, 0);
    }
    /*
     * Section 6.11.4.1 The Rule of Three
     */
    void CreateANamedObject(PrimitiveType pType, string name, Vector3 pos)
    {
        GameObject go = GameObject.CreatePrimitive(pType);
        go.name = name;
        go.transform.position = pos;
    }

    void Section6_11_4_1()
    {
        CreateANamedObject(PrimitiveType.Cube, "MrCube", new Vector3(0, 1, 0));
        CreateANamedObject(PrimitiveType.Cube, "MrsCube", new Vector3(0, 2, 0));
        CreateANamedObject(PrimitiveType.Cube, "MissCube", new Vector3(0, 3, 0));
        CreateANamedObject(PrimitiveType.Cube, "CubeJr", new Vector3(0, 4, 0));
    }
    string[] names = new string[]
    {
        "MrCube",
        "MrsCube",
        "MissCube",
        "CubeJr"
    };

    /*
     * Section 6.11.5 Foreach versus For
     */
    private void Section6_11_5()
    {
        foreach (string s in names)
        {
            Debug.Log(s);
        }

        foreach (string s in names)
        {
            CreateANamedObject(PrimitiveType.Cube, s, new Vector3(0, 1, 0));
        }

        float y = 1.0f;
        foreach (string s in names)
        {
            CreateANamedObject(PrimitiveType.Cube, s, new Vector3(0, y, 0));
            y += 1.0f;
        }
    }
}

