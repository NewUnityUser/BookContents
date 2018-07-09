﻿// Section 3.3 Tokens

class Tokens
{
    /*
     * ┌─────────────┐    ┌─────────────┐
     * │ punctuation │    │ punctuation │ 
     * └─────┬───────┘    └─────┬───────┘
     *       └───┐              └──┐         
     *           │                 │
     *          I'm a little teapot.
     *          ─┬─ ┬ ──┬─── ──┬─── 
     *           │  │   │   ┌──┴───┐
     *           │  │   │   │ noun │ 
     *       ┌───┘  │   │   └──────┘
     *       │      │ ┌─┴─────────┐
     *       │  ┌───┘ │ adjective │
     *       │  │     └───────────┘
     *       │┌─┴───────┐
     *       ││ article │
     *       │└─────────┘
     * ┌─────┴───────────────┐
     * │ contraction: I + am │
     * │ pronoun:            │
     * │ form of to be.      │
     * └─────────────────────┘
     */

    int i = 0;

    /*
     *    ┌────────────┐ ┌─────────┐
     *    │ identifier │ │ literal │ 
     *    └────┬───────┘ └──┬──────┘
     *         └──┐         │         
     *            │   ┌─────┘
     *        int i = 0;
     *         │    │  │ 
     *         │    │  └──┐
     *         │    │  ┌──┴────────┐
     *      ┌──┘    │  │ separator │
     *      │       │  └───────────┘
     *      │  ┌────┴───────┐
     *      │  │ assignment │
     *      │  │ operator   │
     *      │  └────────────┘
     *   ┌──┴──────┐
     *   │ keyword │
     *   └─────────┘
     */

    int j = 0; int k = 1;
    /*
     * the above is perfectly valid, but
     * it's not as readable as:
     * int j = 0;
     * int k = 1;
     */
     
    /*
     * the l below us being assigned a 0 zero.
     * this works since the 0 is a literal of
     * type int, so this is a valid assignment
     */

    int l = 0;

    /* the line below is trying to assign the letter
     * O to the variable m which fails.
     * Uncomment the line to see what the error looks
     * like.
     */
    //int m = O;

    void thing()
    {

    }

    /*    ┌──────────────────┐ ┌───────────────────┐
     *    │ Open Parenthesis │ │ Close Parenthesis │
     *    └───────────┬──────┘ └────┬──────────────┘
     *                │             │
     *                └──────┐┌─────┘
     *            void thing ()
     *                 
     *  the above is called a method declaration, also called a function declaration
     *  So far as object oriented programming is concerned, or OOP Methods were things
     *  that gave an output in return to an input. Functions were things that could
     *  operate in isolation.
     *  
     *  under void thing() is a pair of curly braces
     *  
     *  {
     *  
     *  }
     *  
     *  these indicate the start and end of the work that thing() is going to do.
     *  
     */

    int[] arrayOfNumbers = { 1, (int)3.0, 9000 };

    /*
     *  the above is another use of the curly braces
     * 
     *   ┌──────────────┐ ┌──────────────┐
     *   │ opening curly│ │ closing curly│
     *   │ brace        │ │ brace        │
     *   └───────┬──────┘ └─────┬────────┘
     *   ┌───────┘           ┌──┘       
     *   │                   │
     *   { 1, (int)3.0, 9000 }
     *      │         │
     *      └────┬────┘
     *      ┌────┴──────┐
     *      │ separator │
     *      │ tokens    │
     *      └───────────┘
     *      
     *  (int)3.0
     *  observe this in the middle of the array assignment.
     *      
     *     3.0
     *  ┌───┴───┐
     *  │ dot   │
     *  │ token │
     *  └───────┘
     *   the dot changes the int to a double.
     *   (int) tells C# to change double to int
     *   of course if it were 3.1 then the int
     *   is 3 and the .1 will be lost.
     *  
     *  { 0, 1, 2 }
     *  another more simple example.
     *  
     *  {0,0,0}
     *  the white space isn't necessary
     *  but it's easier to read.
     *  
     */

    void StatementSeparation()
    {
        int a = 0;
        System.Console.Write(a);
        
        // some random scope
        {
            // int a = 1;
            System.Console.Write(a);
        }
    }

    void QuotationMarks()
    {
        System.Console.Write(" use straight quotes. ");
        // this line uses regular " quote marks

        //System.Console.Write(“ this wont work... ”);
        // the line above uses fancy quotes that most word processors will
        // automatically insert when you use quotation marks.
        // uncomment it if you'd like to see where the error occurs

    }

    void imAFunction()
    {
        // this doesn't make modifications to any values
        // outside of this declaration
        System.Console.Write("im a function");
    }

    int v = 0;
    // a variable declared outside of the scope
    // of the method below

    void imAMethod()
    {
        // A method makes
        // modifications to values
        // outside of it's declared scope
        // so if you copied the line from void imAMethod() to the closing }
        // and pasted it in another class, you'd need to include the inv v = 0;
        // or else this Method wouldn't work

        v = 1;
        // the above v is not declared inside of the scope of the method.
    }
}
