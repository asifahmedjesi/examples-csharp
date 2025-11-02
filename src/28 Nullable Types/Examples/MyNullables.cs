namespace Examples;

internal class MyNullables
{
    public static void Run()
    {
        var examples = new MyNullables();

        examples.NullableValueTypes();
        examples.NullableReferenceTypes();
    }

    public void NullableValueTypes()
    {
        Console.WriteLine("Nullable Value Types:");

        int? x = null;  // Nullable<T> Struct
        int y = x ?? 0; // If x is null, y will be 0
        Console.WriteLine($"y = {y}"); // y = 0


        int? i1 = null;
        Console.WriteLine(i1.HasValue); // False
        Console.WriteLine(i1 == null);  // True

        // Equivalent To:
        Nullable<int> i2 = new Nullable<int>();
        Console.WriteLine(!i2.HasValue); // True


        // Implicit and Explicit Nullable Conversions
        int? m = 5;     // implicit [The conversion from T to T? is implicit]
        int n = (int)m; // explicit [from T? to T the conversion is explicit]

        Console.WriteLine();
    }

    public void NullableReferenceTypes()
    {
        Console.WriteLine("Nullable Reference Types:");

        string s1 = null;   // s1 is nullable reference type, generates a compiler warning!
        Console.WriteLine($"s1 == null: {s1 == null}"); // True, with warning

        // The Null-Forgiving Operator
        string s2 = null!;  // OK: s2 is non-nullable reference type, but we are asserting it will not be null
        Console.WriteLine($"s2 == null: {s2 == null}"); // True, but no warning

        string? s3 = null;  // OK: s3 is nullable reference type
        Console.WriteLine($"s3 == null: {s3 == null}"); // True
        
        Console.WriteLine();
    }
}


