using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

/**
 * A class can contain declarations of the following members:
        Constructors
        Constants
        Fields
        Finalizers
        Methods
        Properties
        Indexers
        Operators
        Events
        Delegates
        Classes
        Interfaces
        Structure types
        Enumeration types
 */

public class MyClass
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

    // Field initialization with expressions and call methods
    public static readonly string tempFolder = System.IO.Path.GetTempPath();

    public static void Run()
    {
        MyClass myClass1 = new MyClass();
        MyClass myClass2 = new MyClass { };
        MyClass myClass3 = new();

        var myClass4 = new MyClass();
        var myClass5 = new MyClass { };        
    }
}
