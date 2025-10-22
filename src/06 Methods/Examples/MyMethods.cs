namespace Examples;

internal class MyMethods
{
    public static void Run()
    {
        Console.WriteLine("## Method Features");
        Console.WriteLine();

        var examples = new MyMethods();

        /** Calling Methods */
        examples.MyPrint();

        /** Method Parameters */
        examples.MyPrint("Hello", "World");

        /** Params Keyword */
        examples.MyPrint("Hello", "from", "C#", "Methods");

        /** Calling with named arguments */
        examples.PrintDetails(id: 102, name: "Bob", department: "Finance");

        /** Mixing positional and named arguments (positional must come first) */
        examples.PrintDetails("Charlie", 103, department: "Marketing");

        /** Method Overloading */
        examples.MyPrint("Hello");
        examples.MyPrint(2024);

        /** Optional Parameters */
        examples.MySum(1);

        /** Return Statement */
        string result = examples.GetPrint();

        System.Console.WriteLine(result);

        /** void Type */
        examples.MyMethod();

        Console.WriteLine();
    }

    /** Defining Methods */
    public void MyPrint()
    {
        System.Console.WriteLine("Hello World");
    }

    /** Method Parameters */
    public void MyPrint(string s1, string s2)
    {
        System.Console.WriteLine($"{s1} {s2}");
    }

    /** Params Keyword */
    public void MyPrint(params string[] s)
    {
        foreach (string x in s)
            System.Console.WriteLine(x);
    }

    /** Named Parameters */
    public void PrintDetails(string name, int id, string department)
    {
        Console.WriteLine($"Name: {name}, ID: {id}, Department: {department}");
    }

    /** Method Overloading */
    public void MyPrint(string s)
    {
        System.Console.WriteLine(s);
    }
    public void MyPrint(int i)
    {
        System.Console.WriteLine(i);
    }

    /** Optional Parameters */
    public void MySum(int i, int j = 0, int k = 0)
    {
        System.Console.WriteLine(1 * i + 2 * j + 3 * k);
    }

    /** Return Statement */
    public string GetPrint()
    {
        return "Hello";
    }

    /** void Type */
    public void MyMethod()
    {
        return;
    }

    /** Expression-bodied methods */
    public int Foo(int x) { return x * 2; }
    public int Moo(int x) => x * 2;    
    public string Boo() => "Hello";
    public void DoNothing() { }
    public void PrintHelloWithParam(int x) => Console.WriteLine($"Hello, {x}");
    public void PrintHello() => Console.WriteLine("Hello");
    
}
