using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyStatic
{
    public static void Run()
    {

    }

    #region Instance Members

    // Instance variable (one per object) 
    public float r = 10F;

    // Instance method 
    public float GetArea()
    {
        return ComputeArea(r);
    }

    #endregion

    #region Static Members

    // Static/class variable (only one instance) 
    public static float pi = 3.14F;

    // Static/class method
    public static float ComputeArea(float a)
    {
        return pi * a * a;
    }

    // Static Field
    public static int count = 0; // The default value for a static field will be set only once before it is first used.

    // Static Method
    public static void Dummy()
    {
        count++;
    }

    #endregion

    #region Static Local Functions

    /**
     * A local function automatically captures the context of its enclosing scope, 
     * enabling it to reference members outside of itself such as variables local to
     * the parent method.
     */
    string GetName()
    {
        string name = "John";
        return LocalFunc();
        string LocalFunc() { return name; }
    }

    /**
     * A static local function, on the other hand, does not capture the context of its 
     * enclosing scope. As a result, it cannot access instance members or local variables 
     * from the parent method unless they are explicitly passed as parameters.
     */
    string GetAnotherName()
    {
        string name = "Smith";
        return LocalFunc(name);
        static string LocalFunc(string s) { return s; }
    }

    #endregion    
}


/**
 * Static Classes,
 * A class can also be marked static if it only contains static members and constant fields.
 * A static class cannot be inherited or instantiated into an object.
 */
public static class MyCircle
{
    public const int radius = 10;
    public static float pi = 3.14F;
    // public int count = 0; // This will cause a compile error because non-static fields are not allowed in static classes.

    public static float ComputeArea(float a)
    {
        return pi * a * a;
    }
}


public class MyClass
{
    public static int[] array = new int[5];

    /**
     * The static constructor, 
     * in contrast to the regular instance constructor, will only be run once.
     * This occurs automatically either when an instance of the class is created or when a static member of the class is referenced.
     * Static constructors cannot be called directly and are not inherited.
     * In case the static fields also have initializers, those initial values will be assigned before the static constructor is run.
     */

    // private static MyClass() // ERROR: Static constructors must be parameterless and cannot have access modifiers.
    
    static MyClass()
    {
        for (int i = 0; i < array.Length; i++)
            array[i] = i;
    }
}


public static class MyExtensions
{
    // Extension method
    public static int ToInt(this string s)
    {
        return Int32.Parse(s);
    }
}