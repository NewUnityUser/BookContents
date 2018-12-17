﻿/*
 * Chapter 6.4 Class Constructors
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

 using UnityEngine;

public class ClassConstructors : MonoBehaviour
{
    class Zombie
    {
        public string Name;
        public int BrainsEaten;
        public int HitPoints;
        /*
         * Section 6.4.1 Class Constructors - A Basic Example
         * 
         *          ┌────────────────┐
         *          │Class Identifier│
         *          │These words must│
         *          │match.          │
         *          └─────┬─┬────────┘
         *         ┌──────┘ │
         *       ┌─┴──┐     │       
         * class Zombie ┌───┘
         * {          ┌─┴──┐
         *     public Zombie( )
         *     {            └┬┘
         *     }             │
         * }           ┌─────┴─────────┐
         *             │Arguments for  │
         *             │the constructor│
         *             └───────────────┘
         */
        public Zombie()
        {
            Name = "Zombie";
            BrainsEaten = 0;
            HitPoints = 10;
        }

        /*
         * Section 6.4.1 Class Constructors - A Basic Example continued...
         * use the arguments to populate
         * the class members with data
         */
        public Zombie(string name, int hitPoints)
        {
            Name = name;
            BrainsEaten = 0;
            HitPoints = hitPoints;
        }

        /*
         * Section 6.4.2 Class Constructors - What We've Learned.
         */
        float height;
        GameObject gameObject;
        public Zombie(string name, int hitPoints, Vector3 startPosition)
        {
            Name = name;
            BrainsEaten = 0;
            HitPoints = hitPoints;

            // find the zombie from the Resources folder.
            GameObject go = Resources.Load("ZombiePrimitive") as GameObject;
            // add the resource to the scene.
            Instantiate(go);

            go.name = Name;
            go.transform.position = startPosition;
            height = Random.Range(1f, 3f);
            go.transform.localScale = new Vector3()
            {
                x = 1,
                y = height, // give him a random height
                z = 1
            };
        }
    }

    void Start()
    {
        {
            Zombie rob = new Zombie();
            rob.Name = "Zombie";
            rob.HitPoints = 10;
            rob.BrainsEaten = 0;
        }
        {
            Zombie rob = new Zombie()
            {
                Name = "Zombie",
                HitPoints = 10,
                BrainsEaten = 0
            };
        }
        {
            /*
             * Section 6.4.1 Class Constructors - A Basic Example continued...
             */
            Zombie rob = new Zombie();
        }
        {
            /*
             * Section 6.4.1 Class Constructors - A Basic Example continued...
             * Using the arguments.
             */
            Zombie rob = new Zombie("Rob", 10);
        }
        {
            /*
             * Section 6.4.2 Class Constructors - What We've Learned...
             */
            // Zombie rob = new Zombie("Stubbs", 10, new Vector3(0, 0, 1));

            string[] names = new string[] { "Stubbs", "Rob", "White" };
            for (int i = 0; i < names.Length; i++)
            {
                Vector3 startPosition = new Vector3(i, 0, 0);
                Zombie z = new Zombie(names[i], Random.Range(5, 10), startPosition);
            }
        }
    }
}

