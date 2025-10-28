using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

public class MyDeconstructor
{
    public static void Run()
    {
        var rect = new MyRectangle(3, 4);
        (float width, float height) = rect;         // Deconstruction 
        Console.WriteLine(width + " " + height);    // 3 4

        // 2nd Line is Equivalent to:
        //      float width, height;
        //      rect.Deconstruct(out width, out height);
        // or,
        //      rect.Deconstruct (out var width, out var height);

        // Deconstructing calls allow implicit typing, so we could shorten our call to this:
        //      (var width, var height) = rect;
        // Or simply this:
        //      var(width, height) = rect;

        // deconstructing assignment
        //      float width, height;
        //      (width, height) = rect;

        // You can use a deconstructing assignment to simplify your class’s constructor
        //      public MyRectangle (float width, float height) => (Width, Height) = (width, height);

        // From C# 10, you can mix and match existing and new variables when deconstructing:
        //      double x1 = 0;
        //      (x1, double y2) = rect;
    }
}

public class MyRectangle
{
    public readonly float Width, Height;

    public MyRectangle(float width, float height)
    {
        Width = width;
        Height = height;
    }

    public void Deconstruct(out float width, out float height)
    {
        width = this.Width;
        height = this.Height;
    }

}