using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyLambdaExpressions
{
    public static void Run()
    {
        var examples = new MyLambdaExpressions();
        //examples.LambdaExpressions();
        //examples.CapturingOuterVariables();
        examples.StaticLambdas();
        examples.CapturingIterationVariables();
    }

    public void LambdaExpressions()
    {
        var sqr = int (int x) => x * x;
        var result = sqr(5);
        Console.WriteLine($"Square of 5 is {result}");

        var print = (string message = "Wow Wow") => Console.WriteLine(message);
        print("Hello, World!");
        print();

        // Expression Lambda
        EmptyDelegate e1 = () => Console.WriteLine("EMPTY");
        PrintDelegate p1 = str => Console.WriteLine(str);
        IntProcessorDelegate i1 = i => i * i;

        e1();
        p1("Hello World");
        Console.WriteLine(i1(100));

        // Statement Lambda
        EmptyDelegate e2 = () => 
        { 
            Console.WriteLine("EMPTY"); 
        };
        PrintDelegate p2 = str =>
        {
            Console.WriteLine(str);
        };
        IntProcessorDelegate i2 = i =>
        {
            int result = i * i;
            return result;
        };

        e2();
        p2("Hello C#");
        Console.WriteLine(i2(200));

        Console.WriteLine();
    }

    public void CapturingOuterVariables()
    {
        /** Capturing Outer Variables */
        int factor = 2;        
        Func<int, int> multiplier1 = n => n * factor;
        Console.WriteLine(multiplier1(3)); // 6
        Console.WriteLine();

        factor = 10;
        Console.WriteLine(multiplier1(3)); // 30
        Console.WriteLine();

        int seed = 0;
        Func<int> natural1 = () => seed++;
        Console.WriteLine(natural1()); // 0 
        Console.WriteLine(natural1()); // 1 
        Console.WriteLine(natural1()); // 2 
        Console.WriteLine($"Seed: {seed}"); // 3
        Console.WriteLine();

        seed = 0;
        Func<int> natural2 = () => ++seed;
        Console.WriteLine(natural2()); // 1
        Console.WriteLine(natural2()); // 2
        Console.WriteLine(natural2()); // 3
        Console.WriteLine($"Seed: {seed}"); // 3
        Console.WriteLine();

        /** Closure */
        Func<int> natural = Natural();
        Console.WriteLine(natural()); // 0 
        Console.WriteLine(natural()); // 1
        Console.WriteLine();

        IntProcessorDelegate mult = Processor(2);
        Console.Write($"2x1={mult(1)} ");
        Console.Write($"2x2={mult(2)} ");
        Console.Write($"2x3={mult(3)} ");
        Console.Write($"2x4={mult(4)} ");
        Console.Write($"2x5={mult(5)} ");
        Console.WriteLine();
    }
    private Func<int> Natural()
    {
        int seed = 0;
        return () => seed++; // Returns a closure
    }
    private IntProcessorDelegate Processor(int x)
    {
        return m => m * x;
    } 

    public void StaticLambdas()
    {
        int factor = 2;

        /** Static LAMBDAS */
        Func<int, int> multiplier = static n => n * 2;
        multiplier(factor);

        // Func<int, int> multiplier2 = static n => n * factor; // ERROR: Will not compile, a static anonymous function can not contain a reference to 'factor'
    }

    private void CapturingIterationVariables()
    {
        Console.WriteLine("Capturing Iteration Variables:");

        Action[] actions = new Action[3];
        
        for (int i = 0; i < 3; i++)
            actions[i] = () => Console.Write(i);

        foreach (Action a in actions) a(); // 333
        
        Console.WriteLine();

        /**
         * 
         *  Action[] actions = new Action[3];
         *  
         *  int i = 0;
         *  actions[0] = () => Console.Write (i);
         *  i = 1;
         *  actions[1] = () => Console.Write (i);
         *  i = 2;
         *  actions[2] = () => Console.Write (i);
         *  i = 3;
         *  
         *  foreach (Action a in actions) a(); // 333
         * 
         */


        actions = new Action[3];

        for (int i = 0; i < 3; i++)
        {
            int loopScopedi = i;
            actions[i] = () => Console.Write(loopScopedi);
        }
        
        foreach (Action a in actions) a(); // 012

        Console.WriteLine();
    }
}
