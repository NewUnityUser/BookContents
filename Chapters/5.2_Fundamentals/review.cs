
 ─ │ ┌ ┐ └ ┘ ├ ┤┬ ┴ ┼ ═ ║ ╒ ╓ ╔ ╕ ╖ ╗ ╘ ╙ │ ╚ ╛ ╜ ╝ ╞ ╟ ╠ ╡ ╢ ╣ ╣ ╤ ╥ ╦ ╧ ╨ ╩ ╪ ╫ ╬
 /* Chapter 5.2
 *
 *     C# Example
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
 *
 *     LUA Example
 *     ┌────────────┐ ┌─────────┐
 *     │ identifier │ │ literal │
 *     └────┬───────┘ └──┬──────┘
 *          └──┐         │
 *             │   ┌─────┘
 *       local i = 0
 *         │     │
 *         │     │
 *         │     │   notice there
 *      ┌──┘     │   is no separator
 *      │        │
 *      │   ┌────┴───────┐
 *      │   │ assignment │
 *      │   │ operator   │
 *      │   └────────────┘
 *   ┌──┴──────┐
 *   │ keyword │
 *   └─────────┘
 *
 *     JavaScript Example
 *     ┌────────────┐ ┌─────────┐
 *     │ identifier │ │ literal │
 *     └────┬───────┘ └──┬──────┘
 *          └─┐          │
 *            │   ┌──────┘
 *        var i = 0
 *         │     │
 *         │     │
 *         │     │   notice there
 *      ┌──┘     │   is no separator
 *      │        │
 *      │   ┌────┴───────┐
 *      │   │ assignment │
 *      │   │ operator   │
 *      │   └────────────┘
 *   ┌──┴──────┐
 *   │ keyword │
 *   └─────────┘
 *
 *  //C# For Loop Example
 *  for(int i = 0; i < 10; i++)
 *  {
 *      // code here
 *  }
 * 
 *  //LUA For Loop Example
 *  for i = 0, 10, i++
 *  do
 *      // code here
 *  end
 * 
 *  //C# Class Example
 *  class Rectangle
 *  {
 *      float height;
 *      float width;
 *      Rectangle(float height, float width)
 *      {
 *          this.height = height;
 *          this.width = width;
 *      }
 *  }
 *
 *  // LUA only has functions, without classes.
 *  function object:func(param)
 *  end
 *
 *  //JavaScript Class Example
 *  class Rectangle
 *  {
 *      constructor(height, width)
 *      {
 *          this.height = height;
 *          this.width = width;
 *      }
 *  }
 *
 */