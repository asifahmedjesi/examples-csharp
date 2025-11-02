using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyLoops
{
    public static void Run()
    {
        Console.WriteLine("### Loops Examples");
        Console.WriteLine();

        var examples = new MyLoops();
        examples.WhileLoop();
        examples.DoWhileLoop();
        examples.ForLoop();
        examples.ForEachLoop();
        examples.BreakAndContinue();
    }


    public void WhileLoop()
    {
        Console.WriteLine("## While Loop Example");

        int i = 0;
        while (i < 10)
        {
            System.Console.Write(i++);  // 0-9
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    public void DoWhileLoop()
    {
        Console.WriteLine("## Do While Loop Example");

        int j = 0;
        do
        {
            System.Console.Write(j++);  // 0-9 
        }
        while (j < 10);

        Console.WriteLine();
        Console.WriteLine();
    }

    public void ForLoop()
    {
        Console.WriteLine("## For Loop Example");

        for (int k = 0; k < 10; k++)
        {
            System.Console.Write(k);        // 0-9
        }
        Console.WriteLine();

        for (int k = 0, m = 5; k < 10; k++, m--)
        {
            System.Console.Write(k + m);    // 5 (10x)
        }
        Console.WriteLine();

        for (int k = 0; k < 10;)
        {
            System.Console.Write(k++);      // 0-9
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    public void ForEachLoop()
    {
        Console.WriteLine("## For Each Loop Example");

        int[] a = { 1, 2, 3 };
        foreach (int n in a)
        {
            System.Console.Write(n);        // "123"
        }

        Console.WriteLine();
    }

    public void BreakAndContinue()
    {
        Console.WriteLine("## Break and Continue Example");

        for (int i = 0; i < 10; i++)
        {
            if (i == 5) break;          // end loop
            if (i == 3) continue;       // start next iteration 
            System.Console.Write(i);    // "0124"
        }

        Console.WriteLine();
    }

}
