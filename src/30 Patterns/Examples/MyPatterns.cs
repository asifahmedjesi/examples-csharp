using System.Drawing;

namespace Examples;

/**
 * Patterns are supported in the following contexts: 
 *      After the is operator (variable is pattern)
 *      In switch statements 
 *      In switch expressions
 *      
 * Type Patterns
 *      is: obj is string
 *      is not: obj is not string
 * 
 * Constant Patterns
 *      is: x is 5
 *      is not: x is not 5
 * 
 * Var Patterns
 *      is: obj is var v
 * 
 * Relational Patterns
 *      < > <= >=
 *      
 * Pattern Combinators
 *      From C# 9, you can use the and, or, and not keywords to combine patterns
 *      name.ToUpper() is "JANET" or "JOHN"
 *      c is 'a' or 'e' or 'i' or 'o' or 'u'
 *      n is >= 1 and <= 9
 *      c is >= 'a' and <= 'z' or >= 'A' and <= 'Z'
 * 
 * Property Patterns
 *      point is { X: 3, Y: 4 }
 *      obj is string { Length: 4 }
 *      obj is string s3 && s3.Length == 4
 *      { Scheme: "http", Port: 80 } => true
 *      { Scheme: "http" } when string.IsNullOrWhiteSpace(uri.Query) => true
 *      Uri { Scheme: "http", Port: 60 } httpUri when httpUri.Host.Length < 1000 => true
 *      
 * Positional Patterns
 *      point is Point { X: var xValue, Y: var yValue }
 *      
 * Tuple Patterns
 *      tuple is (1, var message)
 *      (Season.Spring, true)   => 20
 *      
 * List Patterns
 *      numbers is [0, 1, 2, 3, 4]
 *      numbers is [0, 1, _, _, 4]
 *      numbers is [0, 1, var z, 3, 4] && z > 1
 *      numbers is [0, .., 4]
 *      numbers is [0, .. var mid, 4] && mid.Contains(2)
 * 
 */

internal class MyPatterns
{
    public static void Run()
    {
        // Type Patterns
        Console.WriteLine("Type Patterns:");

        object obj = "Hello, World!";
        if (obj is string)
        {
            Console.WriteLine(((string)obj).Length);
        }
        if (obj is string s)
        {
            Console.WriteLine($"String: {s}");
        }

        obj = "HMMM";
        if (obj is not null and string s2 and string { Length: 4 })
        {
            Console.WriteLine($"String: {s2}");
        }
        Console.WriteLine();


        // Constant Patterns
        Console.WriteLine("Constant Patterns:");

        int x = 5;
        if (x is 5)
        {
            Console.WriteLine("x is 5");
        }
        obj = 5;
        if (obj is not 6)
        {
            Console.WriteLine("obj is 5");
        }
        Console.WriteLine();


        // Var Patterns
        Console.WriteLine("Var Patterns:");

        if (obj is var v)
        {
            Console.WriteLine($"Variable: {v}");
        }
        bool IsJanetOrSmith(string name) => name.ToUpper() is var upper && (upper == "JANET" || upper == "SMITH");
        Console.WriteLine(IsJanetOrSmith("Janet")); // True  
        Console.WriteLine();


        // Relational Patterns
        Console.WriteLine("Relational Patterns:");

        decimal bmi = 22.5m;
        string advice = bmi switch
        {
            < 18.5m => "underweight",
            < 25m => "normal",
            < 30m => "overweight",
            _ => "obese"
        };
        Console.WriteLine();


        // Pattern Combinators
        // From C# 9, you can use the and, or, and not keywords to combine patterns
        Console.WriteLine("Pattern Combinators:");

        bool IsJanetOrJohn(string name) => name.ToUpper() is "JANET" or "JOHN";
        Console.WriteLine(IsJanetOrJohn("Janet")); // True

        bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';
        Console.WriteLine(IsVowel('a')); // True

        bool Between1And9(int n) => n is >= 1 and <= 9;
        Console.WriteLine(Between1And9(5)); // True

        bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
        Console.WriteLine(IsLetter('A')); // True

        if (obj is not string)
        {
            Console.WriteLine("obj is not a string");
        }


        // Property Patterns
        Console.WriteLine("Property Patterns:");

        Point point = new Point(3, 4);
        if (point is { X: 3, Y: 4 })
        {
            Console.WriteLine("Point matches the pattern");
        }
        if (obj is string { Length: 4 })
        {
            Console.WriteLine("Object is a string with length 4");
        }
        if (obj is string s3 && s3.Length == 4)
        {
            Console.WriteLine($"Object is a string with length 4: {s3}");
        }

        Uri uri = new Uri("https://www.example.com:443/path?query=123");
        bool shouldAllow = uri switch
        {
            { Scheme: "http", Port: 80 } => true,
            { Scheme: "http" } when string.IsNullOrWhiteSpace(uri.Query) => true,
            { Scheme: "https", Port: 443 } => true,
            { Scheme: "ftp", Port: 21 } => true,
            { IsLoopback: true } => true,
            { Scheme.Length: 4, Port: 80 } => true,
            { Host: { Length: < 1000 }, Port: > 0 } => true,
            _ => false
        };
        shouldAllow = uri switch
        {
            Uri { Scheme: "http", Port: 80 } => true,
            Uri { Scheme: "http", Port: 70 } httpUri => httpUri.Host.Length < 1000,
            Uri { Scheme: "http", Port: 60 } httpUri when httpUri.Host.Length < 1000 => true,
            Uri { Scheme: "http", Port: 90, Host: string host } => host.Length < 1000,
            Uri { Scheme: "https", Port: 443 } => true,
            _ => false
        };
        shouldAllow = uri switch
        {
            { Scheme: "http", Port: 80, Host: var host } => host.Length < 1000,
            { Scheme: "http", Port: 90, Host: string host } => host.Length < 1000,
            { Scheme: "http", Port: 70 } => uri.Host.Length < 1000,
            { Scheme: "http", Port: 60 } when uri.Host.Length < 1000 => true,
            { Scheme: "http", Port: 50, Host: { Length: < 1000 } } => true,
            { Scheme: "https", Port: 443 } => true,
            { Scheme: "ftp", Port: 21 } => true,
            { IsLoopback: true } => true,
            _ => false
        };
        Console.WriteLine();


        // Positional Patterns
        Console.WriteLine("Positional Patterns:");

        if (point is Point { X: var xValue, Y: var yValue })
        {
            Console.WriteLine($"Point has X = {xValue}, Y = {yValue}");
        }
        var p = new Point(2, 2);
        //////Console.WriteLine(p is (2, 2)); // True
        //////Console.WriteLine(p is (var m, var n) && m == n); // True
        Console.WriteLine();


        // Tuple Patterns
        Console.WriteLine("Tuple Patterns:");

        var tuple = (1, "Hello");
        if (tuple is (1, var message))
        {
            Console.WriteLine($"Tuple matches the pattern with message: {message}");
        }

        var q = (2, 3);
        Console.WriteLine(q is (2, 3)); // True        

        (Season season, bool daytime) = (Season.Summer, true);
        int time = (season, daytime) switch
        {
            (Season.Spring, true) => 20,
            (Season.Spring, false) => 16,
            (Season.Summer, true) => 27,
            (Season.Summer, false) => 22,
            (Season.Fall, true) => 18,
            (Season.Fall, false) => 12,
            (Season.Winter, true) => 10,
            (Season.Winter, false) => -2,
            _ => throw new Exception("Unexpected combination")
        };
        Console.WriteLine();


        // List Patterns
        Console.WriteLine("List Patterns:");
        int[] numbers = { 0, 1, 2, 3, 4 };
        Console.Write(numbers is [0, 1, 2, 3, 4]); // True
        Console.Write(numbers is [0, 1, _, _, 4]); // True
        Console.Write(numbers is [0, 1, var z, 3, 4] && z > 1); // True
        Console.Write(numbers is [0, .., 4]); // True
        Console.Write(numbers is [0, .. var mid, 4] && mid.Contains(2)); // True
        Console.WriteLine();
    }
}

internal enum Season { Spring, Summer, Fall, Winter };

