using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyVariables
{
    public static void Run()
    {
        var example = new MyVariables();

        example.VariablesUsingExplicitType();
        Console.WriteLine();

        example.VariablesUsingTypeInference();
        Console.WriteLine();

        example.DefaultValues();
        Console.WriteLine();
    }

    public void VariablesUsingExplicitType()
    {
        Console.WriteLine("## Variables Using Explicit Type:");
        Console.WriteLine();

        /// Signed integers
        sbyte myInt8 = 1;       // -128   to 127
        short myInt16 = 2;      // −32,768 to 32,767
        int myInt32 = 3;        // -2^31  to 2^31 - 1 -> −2,147,483,648 to 2,147,483,647
        long myInt64 = 4L;      // -2^63  to 2^63 - 1 -> −9,223,372,036,854,775,808 to 9,223,372,036,854,775,807

        /// Unsigned integers
        byte uInt8 = 5;         // 0 to 255
        ushort uInt16 = 6;      // 0 to 65,535
        uint uInt32 = 7U;       // 0 to 2^32 - 1 -> 0 to 4,294,967,295
        ulong uInt64 = 8UL;     // 0 to 2^64 - 1 -> 0 to 18,446,744,073,709,551,615        

        /// Floating point numbers
        float myFloat = 1.14F;      // 7 digits of precision
        double myDouble = 1.24;     // 15-16 digits of precision 
        decimal myDecimal = 1.34M;  // 28-29 digits of precision        

        /// Character
        char c = 'a';               // Unicode char

        /// Boolean
        bool b = true;              // bool value

        Console.WriteLine($"myInt8: {myInt8}");
        Console.WriteLine($"myInt16: {myInt16}");
        Console.WriteLine($"myInt32: {myInt32}");
        Console.WriteLine($"myInt64: {myInt64}");
        Console.WriteLine($"uInt8: {uInt8}");
        Console.WriteLine($"uInt16: {uInt16}");
        Console.WriteLine($"uInt32: {uInt32}");
        Console.WriteLine($"uInt64: {uInt64}");        
        Console.WriteLine($"myFloat: {myFloat}");
        Console.WriteLine($"myDouble: {myDouble}");
        Console.WriteLine($"myDecimal: {myDecimal}");
        Console.WriteLine($"c: {c}");
        Console.WriteLine($"b: {b}");        

        Console.WriteLine();
    }

    public void VariablesUsingTypeInference()
    {
        Console.WriteLine("## Variables Using Type Inference:");
        Console.WriteLine();

        var i = 1;
        var ui = 2U;
        var l = 3L;
        var ul = 4UL;
        var f = 1.1F;
        var d = 1.2;
        var m = 1.3M;
        var c = 'a';
        var b = true;

        Console.WriteLine($"i: {i}");
        Console.WriteLine($"ui: {ui}");
        Console.WriteLine($"l: {l}");
        Console.WriteLine($"ul: {ul}");
        Console.WriteLine($"f: {f}");
        Console.WriteLine($"d: {d}");
        Console.WriteLine($"m: {m}");
        Console.WriteLine($"c: {c}");
        Console.WriteLine($"b: {b}");

        Console.WriteLine();
    }

    public void DefaultValues()
    {
        Console.WriteLine("## Default Values:");
        Console.WriteLine();

        Console.WriteLine(default(int));
        Console.WriteLine(default(uint));
        Console.WriteLine(default(long));
        Console.WriteLine(default(ulong));
        Console.WriteLine(default(float));
        Console.WriteLine(default(double));
        Console.WriteLine(default(decimal));
        Console.WriteLine(default(bool));
        Console.WriteLine(default(char));

        int i = default;
        var intValue = default(int);
        uint ui = default;
        long l = default;
        ulong ul = default;
        float f = default;
        double d = default;
        decimal m = default;
        bool b = default;
        char c = default;

        Console.WriteLine(i);
        Console.WriteLine(intValue);
        Console.WriteLine(ui);
        Console.WriteLine(l);
        Console.WriteLine(ul);
        Console.WriteLine(f);
        Console.WriteLine(d);
        Console.WriteLine(m);
        Console.WriteLine(b);
        Console.WriteLine(c);

        Console.WriteLine();
    }

}

//myFloat = (float)myDecimal;   // explicit cast
//myFloat = 12345.6789F;        // rounded to 12345.68
//int myHex = 0xF;              // 15 in hexadecimal (base 16) 
//int myBin = 0b0100;           // 4 in binary (base 2)
//int myBinWithFormat = 0b_0010_0010; // 34 in binary notation (0b)
//Console.WriteLine($"myHex: {myHex}");
//Console.WriteLine($"myBin: {myBin}");
//Console.WriteLine($"myBinWithFormat: {myBinWithFormat}");
