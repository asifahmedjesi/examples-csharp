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
 * If a generic delegate has covariant or contravariant generic type parameters, it can be referred to as a variant generic delegate.
 * 
 * 
 * Generic Delegates That Have Variant Type Parameters in .NET
 * - .NET Framework 4 introduced variance support for generic type parameters in several existing generic delegates:
 *      Action delegates from the System namespace, for example, Action<T> and Action<T1,T2>
 *      Func delegates from the System namespace, for example, Func<TResult> and Func<T,TResult>
 *      The Predicate<T> delegate
 *      The Comparison<T> delegate
 *      The Converter<TInput,TOutput> delegate
 *      
 *      
 * When you assign a method to a delegate, covariance and contravariance provide flexibility for matching a delegate type with a method signature. 
 * Covariance permits a method to have return type that is more derived than that defined in the delegate. 
 * Contravariance permits a method that has parameter types that are less derived than those in the delegate type.
 *      
 * 
 */

public class First { }
public class Second : First { }
public delegate First SampleDelegate(Second a);
public delegate R SampleGenericDelegate<A, R>(A a);

internal class VarianceInDelegatesDemo
{
    public static void Run()
    {
        var examples = new VarianceInDelegatesDemo();
        
        examples.ExampleWithDelegate();
        examples.ExampleWithGenericDelegate();
    }

    // Matching signature.  
    public static First ASecondRFirst(Second second)
    {
        return new First();
    }

    // The return type is more derived.  
    public static Second ASecondRSecond(Second second)
    {
        return new Second();
    }

    // The argument type is less derived.  
    public static First AFirstRFirst(First first)
    {
        return new First();
    }

    // The return type is more derived and the argument type is less derived.  
    public static Second AFirstRSecond(First first)
    {
        return new Second();
    }

    public void ExampleWithImplicitConversion()
    {
        // Assigning a method with a matching signature
        // to a non-generic delegate. No conversion is necessary.  
        SampleDelegate dNonGeneric = ASecondRFirst;

        // Assigning a method with a more derived return type
        // and less derived argument type to a non-generic delegate.  
        // The implicit conversion is used.  
        SampleDelegate dNonGenericConversion = AFirstRSecond;

        // Assigning a method with a matching signature to a generic delegate.  
        // No conversion is necessary.  
        SampleGenericDelegate<Second, First> dGeneric = ASecondRFirst;
        
        // Assigning a method with a more derived return type
        // and less derived argument type to a generic delegate.  
        // The implicit conversion is used.  
        SampleGenericDelegate<Second, First> dGenericConversion = AFirstRSecond;
    }

    public void ExampleWithoutDelegate()
    {
        // The following assignments are not allowed without covariance and contravariance support.  
        SampleDelegate del1 = ASecondRFirst;     // Matching signature.  
        SampleDelegate del2 = ASecondRSecond;    // The return type is more derived.  
        SampleDelegate del3 = AFirstRFirst;      // The argument type is less derived.  
        SampleDelegate del4 = AFirstRSecond;     // The return type is more derived and the argument type is less derived.  
    }

    // delegate First SampleDelegate(Second a);
    public void ExampleWithDelegate()
    {
        SampleDelegate del;

        // Assigning method with matching signature.  
        del = ASecondRFirst;

        // Assigning method with more derived return type.  
        del = ASecondRSecond;   // Covariance  

        // Assigning method with less derived argument type.  
        del = AFirstRFirst;     // Contravariance  

        // Assigning method with more derived return type and less derived argument type.  
        del = AFirstRSecond;    // Covariance and contravariance  
    }

    // delegate R SampleGenericDelegate<A, R>(A a);
    public void ExampleWithGenericDelegate()
    {
        SampleGenericDelegate<Second, First> del;

        // Assigning method with matching signature.  
        del = ASecondRFirst;
        
        // Assigning method with more derived return type.  
        del = ASecondRSecond;   // Covariance  
        
        // Assigning method with less derived argument type.  
        del = AFirstRFirst;     // Contravariance  
        
        // Assigning method with more derived return type and less derived argument type.  
        del = AFirstRSecond;    // Covariance and contravariance  
    }


    // Type T is declared covariant by using the out keyword.  
    public delegate T SampleGenericDelegate<out T>();

    public void ExampleWithOutKeyword()
    {
        SampleGenericDelegate<String> dString = () => " ";

        // You can assign delegates to each other, because the type T is declared covariant.  
        SampleGenericDelegate<Object> dObject = dString;
    }


    // In the following code example, SampleGenericDelegate<String> cannot be explicitly converted to SampleGenericDelegate<Object>, although String inherits Object.
    // You can fix this problem by marking the generic parameter T with the out keyword.
    public delegate T SampleGenericDelegateWithoutOutKeyword<T>();

    public static void Test()
    {
        SampleGenericDelegateWithoutOutKeyword<String> dString = () => " ";

        // You can assign the dObject delegate  
        // to the same lambda expression as dString delegate  
        // because of the variance support for
        // matching method signatures with delegate types.  
        SampleGenericDelegateWithoutOutKeyword<Object> dObject = () => " ";

        // The following statement generates a compiler error  
        // because the generic type T is not marked as covariant.  
        // SampleGenericDelegateWithoutOutKeyword<Object> dObject = dString;  
    }


    /** 
     * If a generic delegate has covariant or contravariant generic type parameters, it can be referred to as a variant generic delegate. 
     */
    public delegate R DCovariant<out R>();
    public delegate void DContravariant<in A>(A a);
    public delegate R DVariant<in A, out R>(A a);

    public void ExampleWithVariantGenericDelegate()
    {
        DCovariant<String> dCovariantString = () => " ";
        DCovariant<Object> dCovariantObject = dCovariantString; // Covariance

        DContravariant<Object> dContravariantObject = (obj) => { };
        DContravariant<String> dContravariantString = dContravariantObject; // Contravariance
        
        DVariant<Object, String> dVariantString = (obj) => " ";
        DVariant<String, Object> dVariantObject = dVariantString; // Covariance and contravariance

        DVariant<String, String> dVariant = (String str) => $"HMM! {str}";
        dVariant("test");
    }


    /** 
     * Don't combine variant delegates. 
     * The Combine method does not support variant delegate conversion and expects delegates to be of exactly the same type. 
     * This can lead to a run-time exception when you combine delegates either by using the Combine method or by using the + operator
     */
    public void ExampleWithCombine()
    {
        Action<object> actObj = x => Console.WriteLine("object: {0}", x);
        Action<string> actStr = x => Console.WriteLine("string: {0}", x);

        // All of the following statements throw exceptions at run time.  
        // Action<string> actCombine = actStr + actObj;  
        // actStr += actObj;  
        // Delegate.Combine(actStr, actObj); 
    }


    /** 
     * Variance for generic type parameters is supported for reference types only 
     */

    // The type T is covariant.  
    public delegate T DVariant<out T>();

    // The type T is invariant.  
    public delegate T DInvariant<T>();

    public void ExampleWithValueType()
    {
        int i = 0;
        DInvariant<int> dInt = () => i;
        DVariant<int> dVariantInt = () => i;

        // All of the following statements generate a compiler error  
        // because type variance in generic parameters is not supported  
        // for value types, even if generic type parameters are declared variant.  
        //DInvariant<Object> dObject = dInt;
        //DInvariant<long> dLong = dInt;
        //DVariant<Object> dVariantObject = dVariantInt;
        //DVariant<long> dVariantLong = dVariantInt;
    }


    
}