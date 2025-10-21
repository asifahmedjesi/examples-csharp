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

        Console.WriteLine("Variables Using Explicit Type:");
        example.VariablesUsingExplicitType();

        Console.WriteLine("Variables Using Type Inference:");
        example.VariablesUsingTypeInference();
    }

    public void VariablesUsingExplicitType()
    {
        /// Signed integers
        sbyte myInt8 = 2;       // -128   to 127
        short myInt16 = 1;      // −32,768 to 32,767
        int myInt32 = 0;        // -2^31  to 2^31 - 1 -> −2,147,483,648 to 2,147,483,647
        long myInt64 = -1L;     // -2^63  to 2^63 - 1 -> −9,223,372,036,854,775,808 to 9,223,372,036,854,775,807

        /// Unsigned integers
        byte uInt8 = 0;         // 0 to 255
        ushort uInt16 = 1;      // 0 to 65,535
        uint uInt32 = 2U;       // 0 to 2^32 - 1 -> 0 to 4,294,967,295
        ulong uInt64 = 3UL;     // 0 to 2^64 - 1 -> 0 to 18,446,744,073,709,551,615

        int myHex = 0xF;        // 15 in hexadecimal (base 16) 
        int myBin = 0b0100;     // 4 in binary (base 2)

        int myBinWithFormat = 0b_0010_0010; // 34 in binary notation (0b)

        /// Floating point numbers
        float myFloat = 3.14F;      // 7 digits of precision
        double myDouble = 3.14;     // 15-16 digits of precision 
        decimal myDecimal = 3.14M;  // 28-29 digits of precision

        myFloat = (float)myDecimal; // explicit cast
        myFloat = 12345.6789F;      // rounded to 12345.68

        /// Character
        char c = 'a';               // Unicode char

        /// Boolean
        bool b = true;              // bool value

        Console.WriteLine("myInt8:", myInt8);
        Console.WriteLine("myInt16:", myInt16);
        Console.WriteLine("myInt32:", myInt32);
        Console.WriteLine("myInt64:", myInt64);
        Console.WriteLine("uInt8:", uInt8);
        Console.WriteLine("uInt16:", uInt16);
        Console.WriteLine("uInt32:", uInt32);
        Console.WriteLine("uInt64:", uInt64);
        Console.WriteLine("myHex:", myHex);
        Console.WriteLine("myBin:", myBin);
        Console.WriteLine("myBinWithFormat:", myBinWithFormat);
        Console.WriteLine("myFloat:", myFloat);
        Console.WriteLine("myDouble:", myDouble);
        Console.WriteLine("myDecimal:", myDecimal);
        Console.WriteLine("c:", c);
        Console.WriteLine("b:", b);

        Console.WriteLine();
    }

    public void VariablesUsingTypeInference()
    {
        var i = 0;
        var ui = 0U;
        var l = 0L;
        var ul = 0UL;
        var f = 0.0F;
        var d = 0.0;
        var m = 0.0M;
        var c = 'a';
        var b = true;

        Console.WriteLine("i:", i);
        Console.WriteLine("ui:", ui);
        Console.WriteLine("l:", l);
        Console.WriteLine("ul:", ul);
        Console.WriteLine("f:", f);
        Console.WriteLine("d:", d);
        Console.WriteLine("m:", m);
        Console.WriteLine("c:", c);
        Console.WriteLine("b:", b);

        Console.WriteLine();
    }
}
