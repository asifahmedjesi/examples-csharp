namespace Examples;

/**
 * Indexers allow an object to be treated as an array. 
 * 
 * They are declared in the same way as properties, except that the this keyword is used instead of a name and their accessors take parameters. 
 * 
 * The parameter list of an indexer is similar to that of a method, except that it must have at least one parameter and 
 * the ref or out modifiers are not allowed.
 */

internal class MyIndexers
{
    public static void Run()
    {
        MyArrayString myArrayString = new MyArrayString();
        myArrayString[0] = "Hello, World!";
        myArrayString[1] = "From Asif.";
        Console.WriteLine($"{myArrayString[0]} {myArrayString[1]}");
    }
}

internal class MyArrayString
{
    string[] data = new string[10];
    string[,] anotherData = new string[10, 10];

    public string this[int i]
    {
        get { return (i >= 0 && i < data.Length) ? data[i] : string.Empty; }        
        set 
        { 
            if (i >= 0 && i < data.Length)
                data[i] = value; 
        }
    }

    public int this[string o]
    {
        get { return !string.IsNullOrWhiteSpace(o) ? System.Array.IndexOf(data, o) : -1; }
    }

    public string this[int i, int j]
    {
        get { return ((i >= 0 && i < anotherData.Length) && (j >= 0 && j < anotherData.Length)) ? anotherData[i, j] : string.Empty; }
        set 
        {
            if ((i >= 0 && i < anotherData.Length) && (j >= 0 && j < anotherData.Length))
                anotherData[i, j] = value; 
        }
    }
}
