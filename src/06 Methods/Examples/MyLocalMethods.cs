namespace Examples;

internal class MyLocalMethods
{
    public static void Run()
    {
        Console.WriteLine("## Local Method:");
        Console.WriteLine();

        var examples = new MyLocalMethods();
        
        examples.WriteCubes();

        var first = examples.GetName();
        var second = examples.GetAnotherName();
        Console.WriteLine($"{first} {second}");

        examples.CountDown();
    }

    /** Local Methods, Static Local Methods */
    public void CountDown()
    {
        int x = 10;
        Recursion(x);
        System.Console.WriteLine("Done");

        void Recursion(int i)
        {
            if (i <= 0) return;
            System.Console.Write($"{i} ");
            System.Threading.Thread.Sleep(1000); // wait 1 second 
            Recursion(i - 1);
        }
    }

    public void WriteCubes()
    {
        Console.WriteLine(Cube(3));
        Console.WriteLine(Cube(4));
        Console.WriteLine(Cube(5));

        int Cube(int value) => value * value * value;
    }

    public string GetName()
    {
        string name = "John";
        return LocalFunc();
        string LocalFunc() { return name; }
    }

    public string GetAnotherName()
    {
        string name = "Smith";
        return LocalFunc(name);
        static string LocalFunc(string s) { return s; }
    }
}
