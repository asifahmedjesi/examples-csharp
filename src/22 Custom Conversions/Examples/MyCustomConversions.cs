namespace Examples;

internal class MyCustomConversions
{
    public static void Run()
    {
        /**
         * implicit conversion to MyNum
         */
        MyNum a = 5;
        Console.WriteLine($"a = {a.val}");

        /**
         * explicit conversion to int
         */
        MyNum b = new MyNum(10);
        int i = (int)b;
        Console.WriteLine($"b = {b.val}, i = {i}");
    }
}

internal class MyNum
{
    public int val;
    public MyNum(int i) { val = i; }

    /** 
     * Implicit Conversion Methods int to MyNum 
     */
    public static implicit operator MyNum(int i) => new MyNum(i);

    /** 
     * Explicit Conversion Methods MyNum to int 
     */
    public static explicit operator int(MyNum a) => a.val;

}
