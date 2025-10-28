namespace Examples;

internal class MyInterfaces
{
    public static void Run()
    {
        MyInterfaces examples = new MyInterfaces();

        var c1 = new Circle();
        var c2 = new Circle();

        //examples.Largest(c1, c2);
        //examples.ClassInterface();
        //examples.DefaultImplementation();
        //examples.ExplicitInterfaceImplementation();
        //examples.ImplementingInterfaceMembersVirtually();
        //examples.ReimplementingInterfaceInSubclass();
        //examples.InterfacesAndBoxing();
        examples.StaticInterfaceMembers();
    }

    // Interface Members
    public void InterfaceMembers()
    {
        IMyInterface myInterface = new MyInterface();
        myInterface.Area = 10;
        int area = myInterface.GetArea();
    }

    // Functionality Interface
    public object Largest(IComparable a, IComparable b)
    {
        return (a.Compare(b) > 0) ? a : b;
    }

    // Class Interface
    public void ClassInterface()
    {
        IMyClass m = new MyClass();
        m.Exposed();
        m.Hidden();

        var myClass = new MyClass();
        myClass.Exposed();
        myClass.Hidden();
        myClass.Print();
    }

    // Default Implementation
    public void DefaultImplementation()
    {
        ILogger logger = new ConsoleLogger();
        logger.Info("This is an info message.");
        logger.Error("This is an error message.");
    }

    // Explicit Interface Implementation
    public void ExplicitInterfaceImplementation()
    {
        Widget w = new Widget();
        w.Foo(); // Widget's implementation of I1.Foo
        ((I1)w).Foo(); // Widget's implementation of I1.Foo 
        ((I2)w).Foo(); // Widget's implementation of I2.Foo
    }

    // Implementing Interface Members Virtually
    public void ImplementingInterfaceMembersVirtually()
    {
        RichTextBox r = new RichTextBox();
        r.Undo(); // RichTextBox.Undo
        ((IUndoable)r).Undo(); // RichTextBox.Undo 
        ((TextBox)r).Undo(); // RichTextBox.Undo
    }

    // Reimplementing an Interface in a Subclass
    public void ReimplementingInterfaceInSubclass()
    {
        RichTextBox r = new RichTextBox();
        r.Undo(); // RichTextBox.Undo Case 1
        ((IUndoable)r).Undo(); // RichTextBox.Undo Case 2
    }

    // Interfaces and Boxing
    public void InterfacesAndBoxing()
    {
        S s = new S();
        s.Foo(); // No boxing.

        I i = s; // Box occurs when casting to interface. 
        i.Foo();
    }

    // Static Interface Members
    public void StaticInterfaceMembers()
    {
        ILogger2.Prefix = "File log: ";

        // ERROR: A static virtual or abstract interface member must be accessed through a type that implements the interface
        // var category = ITypeDescribable.Category;    

        // ERROR: A static virtual or abstract interface member can be accessed only on a type parameter
        // var description = ITypeDescribable.Description;  

        var name = ITypeDescribable.Name;

        var description = CustomerTest.Description;
        var category = CustomerTest.Category;
        var anotherName = CustomerTest.Name;
    }
}


#region Interface Members

public interface IMyInterface
{
    // Interface property 
    int Area { get; set; }

    // Interface indexer
    int this[int index] { get; set; }

    // Interface method 
    int GetArea();

    // Interface event
    event EventHandler MyEvent;

    // Interface delegate
    delegate void MyEventHandler();
}

public class MyInterface : IMyInterface
{
    public int Area { get; set; }
    public int this[int index]
    {
        get { return index; }
        set { }
    }
    public int GetArea()
    {
        return Area;
    }
    public event EventHandler MyEvent;
}

#endregion

#region Functionality Interface

public interface IComparable
{
    int Compare(object o);
}
public class Circle : IComparable
{
    int r;
    public int Compare(object o)
    {
        return r - (o as Circle).r;
    }
}

#endregion

#region Class Interface

public interface IMyClass
{
    void Exposed();
    void Hidden();
}
public class MyClass : IMyClass
{
    public void Exposed() { }
    public void Hidden() { }
    public void Print() { }
}

#endregion

#region Default Implementations

public interface ILogger
{
    void Info(string message);
    void Error(string message)
    {
        Console.WriteLine($"From Default Implementation: {message}");
    }
}
public class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.WriteLine(message);
    }
}

#endregion

#region Explicit Interface Implementation

interface I1 { void Foo(); }
interface I2 { int Foo(); }

public class Widget : I1, I2
{
    public void Foo()
    {
        Console.WriteLine("Widget's implementation of I1.Foo");
    }

    int I2.Foo()
    {
        Console.WriteLine("Widget's implementation of I2.Foo");
        return 42;
    }

}

#endregion

#region Extending an Interface

public interface IUndoable { void Undo(); }
public interface IRedoable : IUndoable { void Redo(); }

#endregion

#region Implementing Interface Members Virtually

public class TextBox : IUndoable
{
    public virtual void Undo() => Console.WriteLine("TextBox.Undo");
}
public class RichTextBox : TextBox
{
    public override void Undo() => Console.WriteLine("RichTextBox.Undo");
}

#endregion


/**
 * An explicitly implemented interface member cannot be marked virtual, 
 * nor can it be overridden in the usual manner. It can, however, be 
 * reimplemented.
 */

#region Reimplementing an Interface in a Subclass

public class TextBox2 : IUndoable
{
    void IUndoable.Undo() => Console.WriteLine("TextBox.Undo");
}
public class RichTextBox2 : TextBox2, IUndoable
{
    public void Undo() => Console.WriteLine("RichTextBox.Undo");
}

#endregion

#region Interfaces and Boxing

public interface I { void Foo(); }
public struct S : I
{
    public S() { }
    public void Foo() { }
}

#endregion

#region Static Interface Members

/**
 * There are two kinds of static interface members:
 *      Static nonvirtual interface members 
 *      Static virtual/abstract interface members
 */

/** Static nonvirtual interface members */
public interface ILogger2
{
    void Log(string text) => Console.WriteLine(Prefix + text);

    static string Prefix = ""; // By default public. You can restrict this by adding an accessibility modifier
                               // (such as private, protected, or internal).

}

/** Static virtual/abstract interface members */
public interface ITypeDescribable
{
    static abstract string Description { get; set; }
    static virtual string Category { get; set; } = "Default static virtual category";    
    static string Name { get; set; } = "Default static name";
    static void PrintDescription() => Console.WriteLine("Default static method");
}
public class CustomerTest : ITypeDescribable
{
    public static string Description { get; set; } = "CustomerTest Description";    // Mandatory 
    public static string Category { get; set; } = "CustomerTest Category";          // Optional
    public static string Name { get; set; } = "CustomerTest Name";                  // Optional
}

/**
 * In addition to methods, properties, and events, operators and conversions are also legal targets for static virtual interface members. 
 * Static virtual interface members are called through a constrained type parameter.
 */

#endregion