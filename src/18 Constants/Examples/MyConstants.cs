namespace Examples;

/**
 * 4 types of constants are available,
 *      1. Local Constants
 *      2. Constant Fields (both instance and static)
 *      3. Readonly Fields
 *      4. in method parameter
 *      
 */

internal class MyConstants
{
    public static void Run()
    {
        /** Local Constants */
        const int a = 10; // compile-time constant
        Console.WriteLine($"a = {a}");

        const string b = "Hello"; // compile-time constant
        Console.WriteLine($"b = {b}");

        const DayOfWeek c = DayOfWeek.Friday; // compile-time constant
        Console.WriteLine($"c = {c}");


        /** Constant Fields */
        var constB = MyClass.b;
        Console.WriteLine($"MyClass.b = {constB}");

        var constI = MyClass.i;
        Console.WriteLine($"MyClass.i = {constI}");

        var constJ = MyClass.j;
        Console.WriteLine($"MyClass.j = {constJ}");


        var myClass = new MyClass();

        var constD = myClass.d;
        Console.WriteLine($"myClass.d = {constD}");
        
        var cosntS = myClass.s;        
        Console.WriteLine($"myClass.s = {cosntS}");


        // Readonly return value from a method
        ref readonly int ab = ref myClass.GetValue();
        // ab = 5; // error: readonly variable

        // Readonly return value from a static method
        ref readonly int cd = ref MyClass.GetStaticValue();
        // cd = 10; // error: readonly variable
    }
}

public class MyClass
{
    public const int b = 5; // compile-time constant field
    public readonly int c = 3; // run-time constant field
    public readonly int d = System.DateTime.Now.Hour; // run-time constant field
    public readonly string s; // run-time constant field
    public readonly int[] e = { 1, 2, 3 }; // readonly array

    public ref readonly string GetString() { return ref s; } // readonly return value
    public ref readonly int GetInt() { return ref c; } // readonly return value


    public static int i;
    public ref readonly int GetValue() { return ref i; } // readonly return value    

    public readonly static int j;
    public static ref readonly int GetStaticValue() { return ref j; } // readonly return value    


    // public const int[] arr = { 1, 2, 3 }; // the expression being assigned must be a compile-time constant
    // public ref readonly int GetInt() { return ref 5; } // readonly return value // ERROR: An expression cannot be used in this context because it may not be passed or returned by reference

    // Readonly in parameter
    public static void Test(in int num) { /* num = 5; */ } // error: readonly method parameter 

    public MyClass() { s = "Hello World"; }
}

public readonly struct MyStruct
{
    public readonly int myVar;    
    public readonly int myInt { get; }
    public readonly int myProperty { get; init; }
    // public readonly int myProperty { get; set; } // ERROR: Auto-implemented instance properties in readonly structs must be read-only
    // public readonly int myProperty { get; private set; } // ERROR: Auto-implemented instance properties in readonly structs must be read-only

    public MyStruct(int var, int prop, int myInt)
    {
        myVar = var;
        myProperty = prop;
        this.myInt = myInt;
    }
}
