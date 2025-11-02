using System.Drawing;

namespace Examples;

internal class MyExceptionHandling
{
    public static void Run()
    {
        var examples = new ErrorHandling();

        //examples.RuntimeExceptionExample();
        examples.TryCatchExample();
        examples.ExceptionFiltersExample();
        examples.ExceptionExtensionExample();
        examples.AnotherTryCatchExample();
        examples.UsingExample();
        examples.AnotherUsingExample();
        //examples.MakeError();
        //examples.AnotherMakeError();

        MyClass.Run();
    }
}

internal class ErrorHandling
{
    public void RuntimeExceptionExample()
    {
        StreamReader sr = new StreamReader("missing.txt"); // Throws Unhandled exception. System.IO.FileNotFoundException: Could not find file '...\missing.txt'.
    }

    public void TryCatchExample()
    {
        StreamReader sr = null;
        try 
        { 
            sr = new StreamReader("missing.txt"); 
        }
        catch (FileNotFoundException e) 
        { 
            Console.WriteLine("Error (FileNotFoundException): " + e.Message); 
        }
        catch (Exception e) 
        { 
            Console.WriteLine("Error (Exception): " + e.Message); 
        }
        finally
        {
            if (sr != null) sr.Close();
        }

        try { }
        catch (Exception) { }

        try { }
        catch { Console.WriteLine("File not found"); }

        Console.WriteLine();
    }
    public void AnotherTryCatchExample()
    {
        Bitmap? b = null;
        try
        {
            b = new Bitmap(100, 50);
            System.Console.WriteLine(b.Width); // "100"
        }
        finally
        {
            if (b != null) b.Dispose();
        }

        Console.WriteLine();
    }

    public void ExceptionFiltersExample()
    {
        try
        {
            StreamReader sr = new StreamReader("missing.txt");
        }
        catch (FileNotFoundException e) when (e.FileName!.Contains("file-not-found.txt")) // Exception Filters
        {
            Console.WriteLine("Missing file (file-not-found.txt): " + e.FileName);
        }
        catch (FileNotFoundException e) when (e.FileName!.Contains(".txt")) // Exception Filters
        {
            Console.WriteLine("Missing file (missing.txt): " + e.FileName);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Error (FileNotFoundException): " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error (Exception): " + e.Message);
        }

        Console.WriteLine();
    }

    public void UsingExample()
    {
        using (Bitmap b = new(100, 50))
        {
            System.Console.WriteLine(b.Width); // "100" 
        }

        Console.WriteLine();
    }

    public void AnotherUsingExample()
    {
        using Bitmap b = new Bitmap(100, 50);
        System.Console.WriteLine(b.Height); // "50"

        Console.WriteLine();
    } // disposed

    public void ExceptionExtensionExample()
    {
        try
        {
            StreamReader sr = new StreamReader("missing.txt");
        }
        catch (Exception e) when (e.LogException())
        {
            // Never reached when e.LogException() returns false

            // execute the following line when e.LogException() returns true
            Console.WriteLine("Error (after e.LogException() called): " + e.Message);
        }
        catch (FileNotFoundException e)
        {
            // Actual handling of exception 
            Console.WriteLine("Error (FileNotFoundException): " + e.Message);
        }       

        Console.WriteLine();
    }

    public void MakeError()
    {
        throw new System.DivideByZeroException("My Error");
    }

    public void AnotherMakeError()
    {
        try
        {
            MakeError();
        }
        catch
        {
            Console.WriteLine("BEFORE CALLING THROW");
            throw; // rethrow error 
        }
    }
}

internal class MyClass
{
    private string _name;
    public string name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(name) + " was null");
    }
    public static void Run()
    {
        MyClass c = new MyClass();
        c.name = null; // exception: name was null
    }
}

internal static class ExceptionExtensions
{
    // Extension method
    public static bool LogException(this Exception e)
    {
        Console.WriteLine("Error (FileNotFoundException): " + e.Message);
        Console.Error.WriteLine($"Exception (from extension method): {e}");
        return false;
    }
}
