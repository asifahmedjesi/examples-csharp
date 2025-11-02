using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyConditionals
{
    public static void Run()
    {
        Console.WriteLine("### Conditionals Examples");
        Console.WriteLine();

        var examples = new MyConditionals();
        examples.IfStatement();
        examples.SwitchStatement();
        examples.SwitchExpression();
        examples.TernaryOperator();
    }

    public void IfStatement()
    {
        Console.WriteLine("## If Statement Example");

        // Get a random integer (0, 1 or 2) 
        int x = new System.Random().Next(3);

        if (x < 1)
        {
            System.Console.WriteLine(x + " < 1");
        }
        else if (x > 1)
        {
            System.Console.WriteLine(x + " > 1");
        }
        else
        {
            System.Console.WriteLine(x + " == 1");
        }

        Console.WriteLine();
    }

    public void SwitchStatement()
    {
        Console.WriteLine("## Switch Statement Example");

        int x = new System.Random().Next(4);

        switch (x)
        {
            case 0:
                System.Console.WriteLine(x + " is 0");
                break;
            case 1:
                System.Console.WriteLine(x + " is 1");
                break;
            default:
                System.Console.WriteLine(x + " is >1");
                break;
        }

        Console.WriteLine();
    }

    public void SwitchExpression()
    {
        Console.WriteLine("## Switch Expression Example");

        int x = new System.Random().Next(4);

        string result = x switch
        {
            0 => "zero",
            1 => "one",
            _ => "more than one"
        };

        System.Console.WriteLine("x is " + result);

        Console.WriteLine();
    }

    public void TernaryOperator()
    {
        Console.WriteLine("## Ternary Operator Example");

        // Get a number between 0.0 and 1.0
        double x = new System.Random().NextDouble();

        x = (x < 0.5) ? 0 : 1; // ternary operator (?:)

        System.Console.WriteLine("x: " + x);

        Console.WriteLine();
    }

}
