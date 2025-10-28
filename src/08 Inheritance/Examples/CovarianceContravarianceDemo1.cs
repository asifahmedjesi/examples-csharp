namespace Examples;

/**
 * Covariance and contravariance support for method groups allows for matching method signatures with delegate types. 
 * 
 * This enables you to assign to delegates not only 
 *      - methods that have matching signatures, 
 *      - but also methods that return more derived types (covariance) or 
 *      - that accept parameters that have less derived types (contravariance) than that specified by the delegate type. 
 * 
 * 
 * Base class reference can hold a derived class object BUT not vice-versa.
 * Covariance: Covariance lets you to pass a derived type object where a base type object is expected Covariance can be applied on delegate, generic, array, interface, etc.
 * Contravariance: Contravariance is applied to parameters. It allows a method with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class
 * 
 * 
 * Covariance allows a "bigger" (less specific) type to be substituted in an API where the original type is only used in an "output" position (e.g. as a return value). 
 * Contravariance allows a "smaller" (more specific) type to be substituted in an API where the original type is only used in an "input" position.
 * 
 */

public class BaseType { }
public class DerivedType : BaseType { }
public delegate BaseType MyDelegate(DerivedType b);

internal class CovarianceContravarianceDemo1
{
    public static void Run()
    {
        var examples = new CovarianceContravarianceDemo1();

        examples.ExampleWithClass();
    }

    // The argument type is less derived.  
    public static BaseType Method1(BaseType a)
    {
        Console.WriteLine("Method1");
        return new BaseType();
    }

    // Matching signature. 
    public static BaseType Method2(DerivedType b)
    {
        Console.WriteLine("Method2");
        return new BaseType();
    }

    // The return type is more derived.
    public static DerivedType Method3(DerivedType b)
    {
        Console.WriteLine("Method3");
        return new DerivedType();
    }

    // The return type is more derived and the argument type is less derived. 
    public static DerivedType Method4(BaseType b)
    {
        Console.WriteLine("Method2");
        return new DerivedType();
    }

    // delegate BaseType MyDelegate(DerivedType b);
    public void ExampleWithClass()
    {
        /** Matching Signature */
        MyDelegate myDel = null;
        myDel = Method2; // normal assignment as per parameter and return type

        /** Covariance */
        // Covariance is applied to return types.
        // delegate expects a return type of base class but we can still assign Method3 that returns derived type and 
        // Thus, covariance allows you to assign a method to the delegate that has a less derived return type.
        myDel = Method3;
        myDel(new DerivedType()); // this will return a more derived type object

        /** Contravariance */
        // Contravariane is applied to method parameters. 
        // Contravariance allows a method with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class.
        myDel = Method1;
        myDel(new DerivedType()); // Contravariance

        /** Covariance and Contravariance */
        myDel = Method4; // Both Covariance and Contravariance
    }

}