using static System.Math;

namespace YourProduct.Component;

class YourClass
{
    public static void Run()
    {
        List<string> items = new() { "apple", "banana", "cherry" }; // Getting namespace from GlobalUsing.cs file

        Console.WriteLine("Running YourClass...");
    }
}

public class Circle
{
    public double Radius { get; set; }
    public double Area
    {
        get { return PI * Pow(Radius, 2); }
    }
}