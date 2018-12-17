﻿/*
 * Chapter 3.8 Classes
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */



/* Class Stuff has Things,  */
/* and can Do A Thing.      */
class Stuff 
{
    int Things;     /* ← Data member     */
    void DoAThing() /* ← Function member */
    {
        //Do the thing!
    }
}

namespace Chapter3_8
{
    using System;
    class Party
    {
        bool PartyTonight = false;/* ← Collect your */
        void DoParty()/*        ┌───── data.        */
        {   /*                 ❶↓                   */
            DateTime today = DateTime.Now;
            /*     test your data                   */
            /*                 ❷↓                   */
            if (today.DayOfWeek == DayOfWeek.Friday)
            {   /* act on your data                 */
                /*             ❸↓                   */
                PartyTonight = true;
            }
        }

        /* * * * * * * * * * * * * * * * * * * * * * * * *
         * pretty much every operation follows the same  *
         * pattern: Get → Check → Set                    *
         * * * * * * * * * * * * * * * * * * * * * * * * */
    }
}

/*
 *              ┌──────────────────┐
 *              │This acts as a    │
 * ╔════════╗   │blueprint to make │
 * ║C# Class║   │an instance of    │
 * ║ Zombie ║←──┤itself.           │
 * ╚═══╤════╝   └──────────────────┘
 *     │ Constructs
 *     │ one of these
 *     ↓        ┌──────────────────┐
 * ┌────────┐   │this Zombie() is  │
 * │ Zombie │←──┤an instance of the│
 * └────────┘   │blueprint that    │
 *              │created it.       │
 *              └──────────────────┘
 */


 /*
  * Section 3.8.1 Objects
  */

class MakeZombies
{               /*   ┌─────────────────┐*/
    class Zombie/* ←─┤This is the plan │*/
    {           /*   │to build a zombie│*/
    }           /*   └─────────────────┘*/
                /*      ┌────────────┐  */
                /*      │this is an  │  */
    void MakeZombie()/* │instance of │  */
    {   /*       ┌──────┤a zombie    │  */
        /*       ↓      └────────────┘  */
        Zombie zombie = new Zombie();
    }
}

class Classes
{
    public int MyInt;
    /*
     * The MyInt becomes a member
     * of this class.
     * 
     * The different data members
     * usually appear at the top of
     * the class when it's written.
     * 
     *  Time day = today; ←① Gather your data
     *  
     *  if ( day == Friday ) ←② Use the data
     *  {
     *      PartyTonight = true; ←③ Act on the data
     *  }
     *  
     */

    public void MyFunction()
    {
    }

    /*
     * The MyFunction()
     * is also a member of
     * the Classes class object
     */
}

/*
 * Section 3.8.1 Objects
 */


class Objects
{
    /*
     * Table is an nested class inside of the Objects
     * class
     */
    class Table
    {
        //Assembly Instructions
        void Instructions()
        {
            //TODO: write instructions on how to build a table.
        }
    }

    Table someTable;
    void BuildTables()
    {
        someTable = new Table();
    }

    enum AmmoType
    {
        Solid,
        FullMetalJacket,
        ArmorPiercing,
        HollowPoint,
        Explosive
    }
    /*
     * Here we show an ammo class
     * where we store a type of
     * ammunition along with
     * how many are stored in this
     * particular instance.
     */
    class Ammunition
    {
        AmmoType ammoType;
        int ammoCount = 10;
    }
}
