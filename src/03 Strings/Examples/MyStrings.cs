using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyStrings
{
    public static void Run()
    {
        var examples = new MyStrings();

        examples.StringInitializationConcatenation();
        examples.StringMembers();
        examples.StringBuilderClass();
    }

    public void StringInitializationConcatenation()
    {
        Console.WriteLine("## STRING INITIALIZATION AND CONCATENATION");
        Console.WriteLine();

        string s1 = "Hello";
        string s2 = "World";
        string s = $"{s1} {s2}"; // Hello World with string interpolation
        Console.WriteLine("String interpolation: " + s);

        string a1 = "\\\\server\\fileshare\\helloworld.cs"; // escape characters
        Console.WriteLine("String with Escape Characters: " + a1);
        string a2 = @"\\server\fileshare\helloworld.cs"; // verbatim string literals                
        Console.WriteLine("String with Verbatim Literal: " + a2);
        Console.WriteLine();

        string verbatim = @"First Line
        Second Line";
        Console.WriteLine("Verbatim String Literal with multi line:\n" + verbatim);
        Console.WriteLine();

        string multiLine = """
            This is a multi-line raw string literals.
            It can span multiple lines.
            """; // raw string literal
        Console.WriteLine("Multi-line Raw String Literal:\n" + multiLine);
        Console.WriteLine();

        string raw1 = """<file path="c:\temp\test.txt"></file>""";  // raw string literal
        Console.WriteLine("Raw String Literal: " + raw1);
        string raw2 = """"We can include """ in this string."""";   // raw string literal
        Console.WriteLine("Raw String Literal with quotes: " + raw2);
        Console.WriteLine();

        string multiLineRaw = """
            Line 1 
            Line 2 
            """;
        Console.WriteLine("Multi-line Raw String Literal:\n" + multiLineRaw);
        Console.WriteLine();

        string stringWithHex = $"15 in hex is {15:X2}";
        Console.WriteLine("String with Hexadecimal Format: " + stringWithHex); // 15 in hex is 0F

        string rawStringLiteralWithStringInterpolation1 = $"""The date and time is {DateTime.Now}""";
        Console.WriteLine($"Interpolated raw string literal 1: {rawStringLiteralWithStringInterpolation1}");
        string rawStringLiteralWithStringInterpolation2 = $$"""{ "TimeStamp": "{{DateTime.Now}}" }""";
        Console.WriteLine($"Interpolated raw string literal 2: {rawStringLiteralWithStringInterpolation2}");
        Console.WriteLine();

        var width = 10;
        var height = 20;
        string interpolatedRawStringLiteral = $$"""
            {
                "width": {{width}},
                "height": {{height}},
                "calculated": {
                    "hypotenuse": {{Math.Sqrt(width * width + height * height)}}, 
                    "area": {{width * height / 2}}
                }
            }
            """;
        Console.WriteLine($"Interpolated raw string literal 3: {interpolatedRawStringLiteral}");

        Console.WriteLine();
    }

    public void StringMembers()
    {
        Console.WriteLine("## STRING MEMBERS");
        Console.WriteLine();

        string a = "Hello World";
        Console.WriteLine("Initial String (a): " + a);

        string b = a.ToLower(); // hello world
        Console.WriteLine($"a.ToLower(): {b}");

        b = a.ToUpper(); // HELLO WORLD
        Console.WriteLine($"a.ToUpper(): {b}");

        b = a.Trim(); // Hello World
        Console.WriteLine($"a.Trim(): {b}");

        b = a.Substring(0, 5); // Hello
        Console.WriteLine($"a.Substring(0, 5): {b}");

        b = a.Replace("World", "C#"); // Hello C#
        Console.WriteLine($"a.Replace(\"World\", \"C#\"): {b}");

        b = a.Insert(0, "My "); // My String 
        Console.WriteLine($"a.Insert(0, \"My \"): {b}");

        b = a.Remove(0, 3); // ing
        Console.WriteLine($"a.Remove(0, 3): {b}");

        bool contains = a.Contains("Hello"); // true
        Console.WriteLine($"a.Contains(\"Hello\"): {contains}");

        int index = a.IndexOf("World"); // 6
        Console.WriteLine($"a.IndexOf(\"World\"): {index}");

        string[] words = a.Split(' '); // ["Hello", "World"]
        Console.WriteLine($"a.Split(' '): [{string.Join(", ", words)}]");

        bool startsWith = a.StartsWith("Hello"); // true
        Console.WriteLine($"a.StartsWith(\"Hello\"): {startsWith}");

        bool endsWith = a.EndsWith("World"); // true
        Console.WriteLine($"a.EndsWith(\"World\"): {endsWith}");

        int length = a.Length; // 11
        Console.WriteLine($"a.Length: {length}");

        string c = a + " - C#"; // Hello World - C#
        Console.WriteLine($"a + \" - C#\": {c}");

        string d = $"Greeting: {a}"; // Greeting: Hello World
        Console.WriteLine($"$\"Greeting: {a}\": {d}");

        Console.WriteLine();
    }

    public void StringBuilderClass()
    {
        Console.WriteLine("## STRINGBUILDER CLASS");
        Console.WriteLine();

        System.Text.StringBuilder sb = new System.Text.StringBuilder("Hello");

        sb.Append(" World");   // Hello World 
        sb.Remove(0, 5);       // World 
        sb.Insert(0, "Bye");   // Bye World

        string s = sb.ToString(); // Bye World

        Console.WriteLine("StringBuilder Result: " + s);

        Console.WriteLine();
    }

}
