namespace Examples;

/**
 * for a method foo(int[] myArray), "passing a reference (object) by value" actually means "passing a copy of the object's address (reference)". 
 * The value of this 'copy', ie. myArray, is initially the Address (reference) of the original object, meaning it points to the original object. 
 * Hence, any change to the content pointed to by myArray will affect the content of the original object. 
 * However, since the 'value' of myArray itself is a copy, any change to this 'value' will not affect the original object nor its contents.
 * 
 * for a method foo(ref int[] refArray), "passing a reference (object) by reference" means "passing the object's address (reference) itself (not a copy)". 
 * That means refArray is actually the original address of the object itself, not a copy. 
 * Hence, any change to the 'value' of refArray, or the content pointed to by refArray is a direct change on the original object itself.
 * 
 */

internal class MyApp
{
    public static void Run()
    {
        Console.WriteLine("## Value Type Vs Reference Type in Method Parameters");
        Console.WriteLine();

        var app = new MyApp();

        #region Pass by Value (Value Type)

        Console.WriteLine("Pass by Value (Value Type):");

        int x = 50;      // value type
        Console.WriteLine($"Value of x before calling the method Set(): {x}");  // 50
        
        app.Set(x);     // pass value of x
        Console.WriteLine($"Value of x after calling the method Set(): {x}");   // 50

        Console.WriteLine();

        #endregion


        #region Pass by Value (Reference Type)

        Console.WriteLine("Pass by Value (Reference Type):");
        
        int[] y = { 100 };  // reference type 
        Console.WriteLine($"Value of y[0] before calling the method Set(): {y[0]}");    // 100

        app.Set(y);         // pass object reference 
        Console.WriteLine($"Value of y[0] after calling the method Set(): {y[0]}");     // 100

        app.Update(y);      // pass object reference to modify the array        
        Console.WriteLine($"Value of y[0] after calling the method Update(): {y[0]}");  // 300

        Console.WriteLine();

        #endregion


        #region ref Keyword (pass by reference for both value and reference type)

        Console.WriteLine("ref Keyword:");

        int a = 400;      // value type
        Console.WriteLine($"Value of a before calling the method Set(): {a}");  // 400

        app.Set(ref a); // pass reference to value type 
        Console.WriteLine($"Value of a after calling the method Set(): {a}");   // 450

        int[] b = { 200 };  // reference type
        Console.WriteLine($"Value of b[0] before calling the method Set(ref): {b[0]}"); // 200

        app.Set(ref b);
        Console.WriteLine($"Value of b[0] after calling the method Set(ref): {b[0]}");  // 500


        // The caller can decide whether to retrieve the returned variable by value(as a copy) or by reference(as an alias).
        // Note that when retrieving by reference, the ref keyword is used both before the method call and before the variable declaration.
        var c = new Container();
        Console.WriteLine($"Value of c.iField before iAlias = 10: {c.iField}"); // 5

        int iCopy = c.GetField(); // retrieve the returned variable by value(as a copy)
        ref int iAlias = ref c.GetField(); // retrieve the returned variable by reference(as an alias)               

        Console.WriteLine($"Value of iCopy: {iCopy}");      // 5
        Console.WriteLine($"Value of iAlias: {iAlias}");    // 5

        iAlias = 10;

        Console.WriteLine($"Value of iAlias after iAlias = 10: {iAlias}");    // 10
        Console.WriteLine($"Value of c.iField after iAlias = 10: {c.iField}");  // 10

        Console.WriteLine();

        #endregion


        #region out Keyword (pass by reference for non-initialized variable)

        Console.WriteLine("out Keyword:");

        long m; // value type        
        app.Set(out m);         // pass reference to unset value type 
        Console.WriteLine($"Value of m after calling the method Set(): {m}"); // 600

        app.Set(out long n);    // pass reference to unset value type
        Console.WriteLine($"Value of n after calling the method Set(): {n}"); // 600

        Console.WriteLine();

        #endregion


        #region in Keyword (read-only pass by reference)

        Console.WriteLine("in Keyword:");

        double d = 100.0; // value type
        app.Set(in d); // pass reference to value type

        Console.WriteLine();

        #endregion

    }

    /** Pass by Value (value type) */
    public void Set(int i) { i = 100; }


    /** Pass by value (Reference type) */
    public void Set(int[] i) 
    { 
        i = new int[] { 200 }; 
        Console.WriteLine($"Value of i[0] inside the method Set(): {i[0]}"); 
    }
    public void Update(int[] i) { i[0] = 300; }


    /** ref Keyword */
    public void Set(ref int i) { i = 450; }
    public void Set(ref int[] i) { i = new int[] { 250 }; }


    /** out Keyword */
    public void Set(out long i) { i = 600; }


    /** in Keyword */
    public void Set(in double d)
    {
        // d = 500; // ERROR: Cannot assign to variable 'd' because it is a readonly variable
        System.Console.WriteLine($"Value of d in Set(in double d): {d}");
    }
}

public class Container
{
    public int iField = 5;
    public ref int GetField()
    {
        return ref iField;
    }
}
