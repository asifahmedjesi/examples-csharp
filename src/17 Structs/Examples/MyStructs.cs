namespace Examples;

internal class MyStructs
{
    public static void Run()
    {
        var p = new Point();
        Console.WriteLine($"Point p: x={p.x}, y={p.y}");

        Point p2;
        // Console.WriteLine($"Point p: x={p2.x}, y={p2.y}"); // This line would cause a compile-time error because p2 is not initialized.

        Point p3 = new(10, 20);
        Console.WriteLine($"Point p3: x={p3.x}, y={p3.y}");
    }
}

public struct Point
{
    public int x, y;
    public static int myStatic = 5;     // allowed 
    public const int myConst = 10;      // allowed

    public int m = 1, n = 1;            // allowed (C# 10)
    public int z { get; set; } = 1;     // allowed (C# 10) 

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}