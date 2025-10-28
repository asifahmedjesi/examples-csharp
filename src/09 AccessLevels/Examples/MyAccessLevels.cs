using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examples.MyInnerBase;

namespace Examples;

internal class MyAccessLevels
{
    public static void Run()
    {
        var myBase = new MyBase();
        myBase.myPublic = 1; // allowed
        // myBase.myProtected   = 1; // inaccessible
        // myBase.myPrivate     = 1; // inaccessible
        myBase.myInternal = 1; // allowed in the same assembly
        myBase.myProtInt = 1; // allowed
        // myBase.myPrivProt    = 1; // inaccessible            
    }
}

public class MyBase
{
    // Unrestricted access 
    public int myPublic;

    // Defining class only 
    private int myPrivate;

    // Derived class
    protected int myProtected;

    // Defining assembly 
    internal int myInternal;

    // Defining assembly or derived class 
    protected internal int myProtInt;

    // Derived class within defining assembly 
    private protected int myPrivProt;

    /**
     * Private Access (defining class)
     */
    void Test()
    {
        myPublic = 0;       // allowed 
        myPrivProt = 0;     // allowed 
        myProtInt = 0;      // allowed         
        myInternal = 0;     // allowed 
        myProtected = 0;    // allowed 
        myPrivate = 0;      // allowed
    }
}


/**
 * Protected Access (derived class)
 */
public class DerivedProtectedAccess : MyBase
{
    void Test()
    {
        myPublic = 0;           // allowed 
        // myPrivate    = 0;    // inaccessible         
        myProtected = 0;        // allowed         
        myInternal = 0;         // allowed
        myProtInt = 0;          // allowed
        myPrivProt = 0;         // allowed                 
    }
}


/**
 * Internal Access (defining assembly)
 */
public class AnyInternalClass
{
    void Test(MyBase m)
    {
        m.myPublic = 0;           // allowed 
        // m.myPrivate    = 0;    // inaccessible         
        // m.myProtected = 0;     // inaccessible         
        m.myInternal = 0;         // allowed
        m.myProtInt = 0;          // allowed
        // m.myPrivProt = 0;      // inaccessible  
    }
}


/**
 * Protected Internal Access (defining assembly or derived class)
 */
public class DerivedProtectedInternal : MyBase
{
    void Test()
    {
        myPublic = 0;           // allowed (from anywhere)
        myProtected = 0;        // allowed (derived class)
        // myPrivate    = 0;    // inaccessible (defining class only)
        myProtInt = 0;          // allowed (defining assembly or derived class)            
        // myPrivProt   = 0;    // inaccessible (derived class within defining assembly)
        // myInternal   = 0;    // inaccessible (defining assembly)
    }
}


/**
 * Private Protected Access (derived class within defining assembly)
 */
public class DerivedPrivateProtected : MyBase
{
    void Test()
    {
        myPublic = 0;           // allowed 
        myProtInt = 0;          // allowed 
        myPrivProt = 0;         // allowed 
        myInternal = 0;         // allowed 
        myProtected = 0;        // allowed 
        // myPrivate    = 0;    // inaccessible
    }
}


/**
 * Public Access (from anywhere)
 */
public class AnyPublicClass
{
    void Test(MyBase m)
    {
        m.myPublic = 0;             // allowed 
        m.myProtInt = 0;            // allowed 
        // m.myPrivProt     = 0;    // inaccessible 
        m.myInternal = 0;           // allowed 
        // m.myProtected    = 0;    // inaccessible 
        // m.myPrivate      = 0;    // inaccessible
    }
}


/**
 * Top-Level Access Levels
 */
internal record MyInternalRecord { }
public record MyPublicRecord { }

internal class MyInternalClass { }
public class MyPublicClass { }

internal interface IMyInternalInterface { }
public interface IMyPublicInterface { }

internal struct MyInternalStruct { }
public struct MyPublicStruct { }

internal enum MyInternalEnum { }
public enum MyPublicEnum { }

internal delegate void MyInternalDelegate();
public delegate void MyPublicDelegate();


// private class MyPrivateClass { }                 // ERROR: CS1527
// protected class MyProtectedClass { }             // ERROR: CS1527
// protected internal class MyProtectedInternal { } // ERROR: CS1527  
// private protected class MyPrivateProtected { }   // ERROR: CS1527
// NOTE:
// Elements defined in a namespace cannot be explicitly declared as private, protected, protected internal or private protected.
// Type declarations in a namespace can have either public or internal access.If no accessibility is specified, internal is the default.


/**
 * Inner Classes
 */
public class MyInnerBase
{
    // Inner classes (nested classes) 
    public class MyPublic { }
    protected internal class MyProtInt { }
    private protected class MyPrivProt { }
    internal class MyInternal { }
    protected class MyProtected { }
    private class MyPrivate { }
}
