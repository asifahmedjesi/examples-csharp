using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyLiterals
{
    public static void Run()
    {
        var example = new MyLiterals();
        example.ShowLiterals();
    }

    public void ShowLiterals()
    {
        // Integer literals
        int decimalLiteral = 42;
        int hexLiteral = 0x2A;
        int binaryLiteral = 0b00101010;

        // Floating-point literals
        double doubleLiteral = 3.14;
        float floatLiteral = 3.14f;
        decimal decimalLiteralType = 3.14m;
        
        // Character and string literals
        char charLiteral = 'A';
        string stringLiteral = "Hello, C#!";
        
        // Boolean literals
        bool trueLiteral = true;
        bool falseLiteral = false;
        
        // Displaying the literals
        Console.WriteLine($"Decimal: {decimalLiteral}, Hex: {hexLiteral}, Binary: {binaryLiteral}");
        Console.WriteLine($"Double: {doubleLiteral}, Float: {floatLiteral}, Decimal Type: {decimalLiteralType}");
        Console.WriteLine($"Char: {charLiteral}, String: {stringLiteral}");
        Console.WriteLine($"Boolean True: {trueLiteral}, Boolean False: {falseLiteral}");
    }
}
