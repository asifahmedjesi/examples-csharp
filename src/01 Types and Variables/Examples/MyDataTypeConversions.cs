using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyDataTypeConversions
{
    public static void Run()
    {
        Console.WriteLine("DATA TYPE CONVERSIONS");
        Console.WriteLine();

        // Implicit conversion
        int myInt = 123;
        long myLong = myInt; // int to long (widening conversion)
        Console.WriteLine($"Implicit conversion: {myInt} to {myLong}");

        // Explicit conversion (casting)
        double myDouble = 123.456;
        int myIntFromDouble = (int)myDouble; // double to int (narrowing conversion)
        Console.WriteLine($"Explicit conversion: {myDouble} to {myIntFromDouble}");

        // Using Convert class
        string myString = "456";
        int myIntFromString = Convert.ToInt32(myString); // string to int
        Console.WriteLine($"Convert class: {myString} to {myIntFromString}");

        Console.WriteLine();
    }
}
