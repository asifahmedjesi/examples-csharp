namespace Examples;

/**
 * Covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments. 
 * Covariance preserves assignment compatibility and contravariance reverses it. 
 * 
 */

internal class CovarianceAndContravarianceDemo
{
    public static void Run()
    {
        var examples = new CovarianceAndContravarianceDemo();

        examples.ExampleWithAssignmentCompatibility();
    }

    ///  The following code demonstrates the difference between assignment compatibility, covariance, and contravariance.
    public void ExampleWithAssignmentCompatibility()
    {
        /** Covariance (return more derived types) */

        IEnumerable<string> strings = new List<string> { "Hello, Covariance" };

        // An object that is instantiated with a more derived type argument
        // is assigned to an object instantiated with a less derived type argument.
        // Assignment compatibility is preserved.
        IEnumerable<object> objects = strings; // Covariance: more derived to less derived

        Console.WriteLine(objects);
        Console.WriteLine();


        /** Contravariance (accept parameters that have less derived types) */

        Action<object> actObject = obj => Console.WriteLine(obj);

        // An object that is instantiated with a less derived type argument
        // is assigned to an object instantiated with a more derived type argument.
        // Assignment compatibility is reversed.
        Action<string> actString = actObject; // Contravariance: less derived to more derived

        actString("Hello, Contravariance!");
        Console.WriteLine();
    }


    public object GetObject() { return null; }
    public void SetObject(object obj) { }

    public string GetString() { return ""; }
    public void SetString(string str) { }

    public void Test()
    {
        // Covariance. A delegate specifies a return type as object,  
        // but you can assign a method that returns a string.  
        Func<object> objectDel = GetString;

        // Contravariance. A delegate specifies a parameter type as string,  
        // but you can assign a method that takes an object.  
        Action<string> stringDel = SetObject;
    }
}