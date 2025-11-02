namespace Examples;

/**
 * 
 * These are the possible constraints:
 *      where T : base-class    // Base-class constraint
 *      where T : interface     // Interface constraint
 *      where T : class         // Reference-type constraint
 *      where T : class?        // (See "Nullable Reference Types" in Chapter 4) 
 *      where T : struct        // Value-type constraint (excludes Nullable types)
 *      where T : unmanaged     // Unmanaged constraint
 *      where T : new()         // Parameterless constructor constraint 
 *      where U : T             // Naked type constraint
 *      where T : notnull       // Non-nullable value type, or (from C# 8)
 *                              // a non-nullable reference type
 * 
 */

internal class MyGenerics
{
    public static void Run()
    {
        var examples = new MyGenerics();

        // Calling Generic Methods
        examples.GenericMethodExample();

        // Creating Generic Classes
        Point<short> p = new Point<short>();
        Console.WriteLine();

        // typeof and Unbound Generic Types
        Type a1 = typeof(A<>);  // Unbound type (notice no type arguments). 
        Type a2 = typeof(A<,>); // Use commas to indicate multiple type args.
        Type a3 = typeof(A<int, int>);
        Console.WriteLine($"a1: {a1}, a2: {a2}, a3: {a3}");
        Console.WriteLine();

        // Generic Delegate
        MyDelegate<string> d = MyGenericDelegateClass.Print;
        Console.WriteLine();

        // Generic Event
        MyEventClass myEventClass = new MyEventClass();
        myEventClass.MyEvent += (sender, eventArgs) => Console.WriteLine("Event triggered!");

        // Generics and Objects        
        System.Collections.ArrayList a;         // .NET object container         
        System.Collections.Generic.List<int> b; // .NET generic container (preferred) 
    }

    public void GenericMethodExample()
    {        
        int a = 0, b = 1;
        Console.WriteLine($"a: {a}, b: {b}"); // a: 0, b: 1
        Swap<int>(ref a, ref b);
        Console.WriteLine($"a: {a}, b: {b}"); // a: 1, b: 0
        Console.WriteLine();

        Swap<int>(ref a, ref b); // create & call Swap<int> 
        Swap<int>(ref a, ref b); // call Swap<int>

        long c = 0, d = 1;
        Swap<long>(ref c, ref d); // create & call Swap<long>
        Swap<long>(ref c, ref d); // call Swap<long>
    }

    #region Generic Methods

    public void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    #endregion

    #region Generic Type Parameters

    public void Dummy<T>() { }
    public void Dummy<T, U>() { }

    #endregion

    #region Default Value

    public void Init<T>(ref T a)
    {
        a = default(T);
    }
    public void Reset<T>(ref T a)
    {
        a = default; // same as default(T)
    }

    #endregion
}

#region Generic Classes

public class GenericClass<T>
{
    public T Value { get; set; }
    public GenericClass(T value)
    {
        Value = value;
    }
}

public class Point<T>
{
    public T x, y;
}

#endregion

#region Generic Class Inheritance

/**
 * A generic class can inherit from a non-generic class, also called a concrete class. 
 * Second, it can inherit from another generic class that has its type argument specified, a so-called closed constructed base class. 
 * Finally, it can inherit from an open constructed base class, which is a generic class that has its type argument left unspecified.
 */
public class BaseConcrete { }
public class BaseGeneric<T> { }
public class Gen1<T> : BaseConcrete { }     // concrete base class
public class Gen2<T> : BaseGeneric<int> { } // closed constructed base class
public class Gen3<T> : BaseGeneric<T> { }   // open constructed base class

public class GenericClass<T, U> : GenericClass<T>
{
    public U SecondValue { get; set; }
    public GenericClass(T value, U secondValue) : base(value)
    {
        SecondValue = secondValue;
    }
}

public class BaseMultiple<T, U, V> { }
public class Gen4<T, U> : BaseMultiple<T, U, int> { }

/**
 * This also means that a non-generic class can only inherit from a closed constructed base class and not from an open one, 
 * because a non-generic class cannot specify any type arguments when it is instantiated.
 */
public class Con1 : BaseGeneric<int> { }    // ok 
// public class Con2 : BaseGeneric<T> { }   // error

#endregion

#region typeof and Unbound Generic Types

public class A<T> { }
public class A<T1, T2> { }

public class B<T> 
{ 
    void X() 
    { 
        Type t = typeof(T); 
    } 
}

#endregion

#region Generic Interfaces

/**
 * Interfaces that are declared with type parameters become generic interfaces. 
 * Generic interfaces have the same two purposes as regular interfaces. 
 * They are either created to expose members of a class that will be used by other classes, or to force a class to implement a specific functionality. 
 * When a generic interface is implemented, the type argument must be specified. The generic interface can be implemented by both generic and non-generic classes.
 */

// Generic functionality interface 
public interface IGenericCollection<T>
{
    void store(T t);
}

// Non-generic class implementing generic interface 
public class Box : IGenericCollection<int>
{
    public int myBox;
    public void store(int i) { myBox = i; }
}

// Generic class implementing generic interface 
public class GenericBox<T> : IGenericCollection<T>
{
    public T myBox;
    public void store(T t) { myBox = t; }
}

#endregion

#region Generic Delegates

public delegate void MyDelegate<T>(T arg);

public class MyGenericDelegateClass
{    
    public static void Print(string s)
    {
        Console.WriteLine(s);
    }
}

#endregion

#region Generic Events

public delegate void MyEventDelegate<T, U>(T sender, U eventArgs);

public class MyEventClass
{
    public event MyEventDelegate<MyEventClass, System.EventArgs> MyEvent;
    protected virtual void OnMyEvent(System.EventArgs e)
    {
        MyEvent?.Invoke(this, e);
    }
}

#endregion

#region Generics and Object

// Object container class
class ConcreteObj 
{ 
    public object o; 
}

// Generic container class (preferred) 
class GenericObj<T> 
{ 
    public T o; 
}

#endregion

#region Constraints

/**
 * 
 * These are the possible constraints:
 *      where T : base-class    // Base-class constraint
 *      where T : interface     // Interface constraint
 *      where T : class         // Reference-type constraint
 *      where T : class?        // (See "Nullable Reference Types" in Chapter 4) 
 *      where T : struct        // Value-type constraint (excludes Nullable types)
 *      where T : unmanaged     // Unmanaged constraint
 *      where T : new()         // Parameterless constructor constraint 
 *      where U : T             // Naked type constraint
 *      where T : notnull       // Non-nullable value type, or (from C# 8)
 *                              // a non-nullable reference type
 * 
 */

public class GenericClassWithConstraints<T> where T : class, new()
{
    public T Instance { get; set; }
    public GenericClassWithConstraints()
    {
        Instance = new T(); // T must have a parameterless constructor
    }
}


public class C<T> where T : struct { }          // value type

public class D<T> where T : class { }           // reference type

public class B { }
public class E<T> where T : B { }               // be/derive from base class

public interface I { }
public class G<T> where T : I { }               // be/implement interface

public class H<T> where T : new() { }           // no parameter constructor

public class J<T> where T : class, new() { }    // reference type with parameterless constructor


public class SomeClass { }
public interface ISomeInterface { }

public class SomeGenericClass<T, U>
    where T : SomeClass, ISomeInterface
    where U : new()
{ }


public class MyClass<T> where T : new() { }

public class MyChild<T> : MyClass<T>
    where T : MyClass<T>, new()
{ }


class Base<T> where T : new() { }

class Derived<T> : Base<T> 
    where T : Base<T>, new()
{ }

#endregion

#region Multiple Constraints

public class J<T, U>
    where T : class, I
    where U : I, new()
{ }

#endregion

#region Why Use Constraints

/**
 * Aside from restricting the use of a generic method or class to only certain parameter types, 
 * another reason for applying constraints is to increase the number of allowed operations and method calls supported by the constraining type. 
 * 
 * An unconstrained type may only use the System.Object methods.
 * 
 * However, by applying a base class constraint, the accessible members of that base class also become available.
 */

public class Person
{
    public string name;
}
public class PersonNameBox<T> where T : Person
{
    public string box;
    public void StorePersonName(T a)
    {
        box = a.name;
    }
}

#endregion