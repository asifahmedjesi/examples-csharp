namespace Examples;

internal class MyConstructors
{
    public static void Run()
    {
        var r1 = new Rectangle();
        var r2 = new Rectangle() { x = 20, y = 10 };
        var r3 = new Rectangle { x = 20, y = 10 };
        var r4 = new { x = 20, y = 10 };

        Rectangle r5 = new();
        Rectangle r6 = new() { x = 20, y = 10 };
    }
}

internal class Rectangle
{
    public int x = 10, y = 20;

    public Rectangle() : this(10, 5) {}
    public Rectangle(int a) : this(a, a) {}
    public Rectangle(int a, int b) { this.x = a; this.y = b; }
}
