namespace Examples;

/**
 * Delegates are type-safe function pointers that allow methods to be passed as parameters.
 * Delegates can be used to define callback methods, event handlers, and more.
 * Delegates can be defined using the 'delegate' keyword, and they can be invoked like methods.
 * Delegates can be used in various styles, including:
 *      1. Old style (Using a delegate instance)
 *      2. New style (Using operator overloading)
 *      3. Anonymous Methods
 *      4. Lambda Expressions");
 * 
 * 
 */

public class MyDelegates
{
    public static void Run()
    {
        var examples = new MyDelegates();

        // Old style (Using a delegate instance)
        examples.OldStyleUsingDelegateInstanceExample();

        // New style (Using operator overloading)
        examples.NewStyleUsingOperatorOverloadingExample();

        // Anonymous Methods
        examples.AnonymousMethodsExample();

        // Lambda Expressions
        examples.LambdaExpressionsExample();

        // Expression Lambda
        IntProcessorDelegate d1 = i => i * i;

        // Statement Lambda
        IntProcessorDelegate d2 = i =>
        {
            int result = i * i;
            return result;
        };

        // Delegates as Parameters Example
        Console.WriteLine("Delegates as Parameters:");
        PersonDB p = new PersonDB();
        p.Process(Client.PrintName);
        Console.WriteLine();

        // Multicast Delegates Example
        Console.WriteLine("MulticastDelegate:");
        EmptyDelegate del = MyMulticastDelegates.Hi; // Add Hi method

        del += MyMulticastDelegates.Bye; // Add Bye method
        del(); // Invokes both Hi and Bye methods, output: "HiBye"

        del -= MyMulticastDelegates.Hi;
        del(); // Invokes only Bye method, output: "Bye"      

        Console.WriteLine();


        // Mehod Singature
        // delegate MyBase ChildDelegate(MyDerived d)
        ChildDelegate delBaseBase       = MyMehodSignature.TestBaseBase;        // less derived to more derived allowed
        ChildDelegate delDerivedBase    = MyMehodSignature.TestDerivedBase;     // less derived to more derived allowed
        ChildDelegate delBaseDerived    = MyMehodSignature.TestBaseDerived;
        ChildDelegate delDerivedDerived = MyMehodSignature.TestDerivedDerived;        

        // delBaseBase(new MyBase());       // less derived to more derived allowed
        // delDerivedBase(new MyBase());    // less derived to more derived allowed
        delBaseDerived(new MyDerived());        
        delDerivedDerived(new MyDerived());
    }

    public void OldStyleUsingDelegateInstanceExample()
    {
        /** Old style (Using a delegate instance) */
        Console.WriteLine("Old Style Using Delegate Instance Example:");
        EmptyDelegate a = new EmptyDelegate(MyApp.PrintHello);
        PrintDelegate e = new PrintDelegate(MyApp.PrintString);
        IntProcessorDelegate i = new IntProcessorDelegate(MyApp.ProcessInt);
    }

    public void NewStyleUsingOperatorOverloadingExample()
    {
        /** New style (Using operator overloading) */
        Console.WriteLine("New Style Using Operator Overloading Example:");
        EmptyDelegate b = MyApp.PrintHello;
        PrintDelegate f = MyApp.PrintString;
        IntProcessorDelegate j = MyApp.ProcessInt;
    }

    public void AnonymousMethodsExample()
    {
        /** Anonymous Methods */
        Console.WriteLine("Anonymous Methods Example:");
        EmptyDelegate b = delegate () { Console.WriteLine("Hello World!!!"); };
        PrintDelegate f = delegate (string s) { Console.WriteLine(s); };
        IntProcessorDelegate j = delegate (int i) { return i * i; };

        EmptyDelegate a = delegate () { MyApp.PrintHello(); };
        PrintDelegate e = delegate (string s) { MyApp.PrintString(s); };
        IntProcessorDelegate i = delegate (int i) { return MyApp.ProcessInt(i); };
    }

    public void LambdaExpressionsExample()
    {
        /** Lambda Expressions */
        Console.WriteLine("Lambda Expressions Example:");
        EmptyDelegate a = () => Console.WriteLine("Hello World!!!");
        PrintDelegate e = (string s) => Console.WriteLine(s);
        IntProcessorDelegate i = (int i) => i * i;

        EmptyDelegate c = () => MyApp.PrintHello();
        PrintDelegate g = (string s) => MyApp.PrintString(s);
        IntProcessorDelegate k = (int i) => MyApp.ProcessInt(i);
    }
}

#region Delegate Declarations

public delegate void EmptyDelegate();
public delegate void PrintDelegate(string str);
public delegate int IntProcessorDelegate(int i);

#endregion

#region Delegate Definitions

public class MyApp
{
    public static void PrintHello()
    {
        Console.WriteLine("Hello World!!!");
    }
    public static void PrintString(string s)
    {
        Console.WriteLine(s);
    }
    public static int ProcessInt(int i)
    {
        return i * i;
    }
}

#endregion

#region Delegates as Method Parameters

public delegate void ProcessPersonDelegate(string name);

public class PersonDB
{
    public string[] persons = { "John", "Sam", "Dave" };

    public void Process(ProcessPersonDelegate f)
    {
        foreach (string person in persons) f(person);
    }
}

public class Client
{
    public static void PrintName(string name)
    {
        System.Console.WriteLine(name);
    }
}

#endregion

#region Delegate Signature (Covariance and Contravariance)

/**
 * Please check section 21 Covariance and Contravariance for details.
 */
internal class MyBase { }
internal class MyDerived : MyBase { }
internal delegate MyBase ChildDelegate(MyDerived d);

internal class MyMehodSignature
{
    public static MyBase TestBaseDerived(MyDerived o)
    {
        return new MyBase();
    }
    public static MyBase TestBaseBase(MyBase o)
    {
        return new MyBase();
    }
    public static MyDerived TestDerivedDerived(MyDerived o)
    {
        return new MyDerived();
    }
    public static MyDerived TestDerivedBase(MyBase o)
    {
        return new MyDerived();
    }
}

#endregion

#region Multicast Delegates

public class MyMulticastDelegates
{
    public static void Hi() { System.Console.WriteLine("Hi"); }
    public static void Bye() { System.Console.WriteLine("Bye"); }
}

#endregion