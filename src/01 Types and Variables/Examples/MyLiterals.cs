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
        
        example.UsingLiterals();
        Console.WriteLine();

        example.UsingTypeInference();
        Console.WriteLine();
    }

    public void UsingLiterals()
    {
        Console.WriteLine("## Using Literals:");
        Console.WriteLine();

        // Integer literals
        Console.WriteLine("Interger Literals:");
        Console.WriteLine($"1: TypeName {1.GetType().Name}, TypeFullName {1.GetType().FullName}, BaseTypeFullName {1.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"1U: TypeName {1U.GetType().Name}, TypeFullName {1U.GetType().FullName}, BaseTypeFullName {1U.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1U.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"1L: TypeName {1L.GetType().Name}, TypeFullName {1L.GetType().FullName}, BaseTypeFullName {1L.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1L.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"1UL: TypeName {1UL.GetType().Name}, TypeFullName {1UL.GetType().FullName}, BaseTypeFullName {1UL.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1UL.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Floating-point literals
        Console.WriteLine("Floating-Point Literals:");
        Console.WriteLine($"1.0F: TypeName {1.0F.GetType().Name}, TypeFullName {1.0F.GetType().FullName}, BaseTypeFullName {1.0F.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1.0F.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"1.0: TypeName {1.0.GetType().Name}, TypeFullName {1.0.GetType().FullName}, BaseTypeFullName {1.0.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1.0.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"1.0D: TypeName {1.0D.GetType().Name}, TypeFullName {1.0D.GetType().FullName}, BaseTypeFullName {1.0D.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1.0D.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"1.0M: TypeName {1.0M.GetType().Name}, TypeFullName {1.0M.GetType().FullName}, BaseTypeFullName {1.0M.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {1.0M.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Character and string literals
        Console.WriteLine("Character and String Literals:");
        Console.WriteLine($"'a': TypeName {'a'.GetType().Name}, TypeFullName {'a'.GetType().FullName}, BaseTypeFullName {'a'.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {'a'.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"\"Hello C#!\": TypeName {"Hello C#!".GetType().Name}, TypeFullName {"Hello C#!".GetType().FullName}, BaseTypeFullName {"Hello C#!".GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {"Hello C#!".GetType().BaseType?.BaseType?.FullName ?? "NONE"}");
        Console.WriteLine();

        // Boolean literals
        Console.WriteLine("Boolean Literals:");
        Console.WriteLine($"true: TypeName {true.GetType().Name}, TypeFullName {true.GetType().FullName}, BaseTypeFullName {true.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {true.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"false: TypeName {false.GetType().Name}, TypeFullName {false.GetType().FullName}, BaseTypeFullName {false.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {false.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Tuple literal
        Console.WriteLine("Tuple Literal:");
        Console.WriteLine($"(1, \"Hello\"): TypeName {(1, "Hello").GetType().Name}, TypeFullName {(1, "Hello").GetType().FullName}, BaseTypeFullName {(1, "Hello").GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {(1, "Hello").GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();
    }

    public void UsingTypeInference()
    { 
        Console.WriteLine("## Using Type Inference:");
        Console.WriteLine();

        // Integer literals
        var sbyteValue = (sbyte)1;
        var byteValue = (byte)1;
        var shortValue = (short)1;
        var ushortValue = (ushort)1;
        var intValue = 1;
        var uintValue = 1U;
        var longValue = 1L;
        var ulongValue = 1UL;

        Console.WriteLine("Integer Literals:");
        Console.WriteLine($"sbyteValue: {sbyteValue}, TypeName {sbyteValue.GetType().Name}, TypeFullName {sbyteValue.GetType().FullName}, BaseTypeFullName {sbyteValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {sbyteValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"byteValue: {byteValue}, TypeName {byteValue.GetType().Name}, TypeFullName {byteValue.GetType().FullName}, BaseTypeFullName {byteValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {byteValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"shortValue: {shortValue}, TypeName {shortValue.GetType().Name}, TypeFullName {shortValue.GetType().FullName}, BaseTypeFullName {shortValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {shortValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"ushortValue: {ushortValue}, TypeName {ushortValue.GetType().Name}, TypeFullName {ushortValue.GetType().FullName}, BaseTypeFullName {ushortValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {ushortValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"intValue: {intValue}, TypeName {intValue.GetType().Name}, TypeFullName {intValue.GetType().FullName}, BaseTypeFullName {intValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {intValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"uintValue: {uintValue}, TypeName {uintValue.GetType().Name}, TypeFullName {uintValue.GetType().FullName}, BaseTypeFullName {uintValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {uintValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"longValue: {longValue}, TypeName {longValue.GetType().Name}, TypeFullName {longValue.GetType().FullName}, BaseTypeFullName {longValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {longValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"ulongValue: {ulongValue}, TypeName {ulongValue.GetType().Name}, TypeFullName {ulongValue.GetType().FullName}, BaseTypeFullName {ulongValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {ulongValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Floating-point literals        
        float floatValue = 3.14F;
        double doubleValue = 3.14;
        double doubleValueWithSuffix = 3.14D;
        decimal decimalValue = 3.14M;

        Console.WriteLine("Floating-Point Literals:");
        Console.WriteLine($"floatValue: {floatValue}, TypeName {floatValue.GetType().Name}, TypeFullName {floatValue.GetType().FullName}, BaseTypeFullName {floatValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {floatValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"doubleValue: {doubleValue}, TypeName {doubleValue.GetType().Name}, TypeFullName {doubleValue.GetType().FullName}, BaseTypeFullName {doubleValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {doubleValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"doubleValueWithSuffix: {doubleValueWithSuffix}, TypeName {doubleValueWithSuffix.GetType().Name}, TypeFullName {doubleValueWithSuffix.GetType().FullName}, BaseTypeFullName {doubleValueWithSuffix.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {doubleValueWithSuffix.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"decimalValue: {decimalValue}, TypeName {decimalValue.GetType().Name}, TypeFullName {decimalValue.GetType().FullName}, BaseTypeFullName {decimalValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {decimalValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Character and string literals
        char charValue = 'A';
        string stringValue = "Hello C#!";

        Console.WriteLine("Character and String Literals:");
        Console.WriteLine($"charValue: {charValue}, TypeName {charValue.GetType().Name}, TypeFullName {charValue.GetType().FullName}, BaseTypeFullName {charValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {charValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"stringValue: {stringValue}, TypeName {stringValue.GetType().Name}, TypeFullName {stringValue.GetType().FullName}, BaseTypeFullName {stringValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {stringValue.GetType().BaseType?.BaseType?.FullName ?? "NONE"}");
        Console.WriteLine();

        // Boolean literals
        bool trueLiteral = true;
        bool falseLiteral = false;

        Console.WriteLine("Boolean Literals:");
        Console.WriteLine($"trueLiteral: {trueLiteral}, TypeName {trueLiteral.GetType().Name}, TypeFullName {trueLiteral.GetType().FullName}, BaseTypeFullName {trueLiteral.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {trueLiteral.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"falseLiteral: {falseLiteral}, TypeName {falseLiteral.GetType().Name}, TypeFullName {falseLiteral.GetType().FullName}, BaseTypeFullName {falseLiteral.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {falseLiteral.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Tuple literal
        var tupleValue = (1, "Hello");

        Console.WriteLine("Tuple Literal:");
        Console.WriteLine($"tupleValue: {tupleValue}, TypeName {tupleValue.GetType().Name}, TypeFullName {tupleValue.GetType().FullName}, BaseTypeFullName {tupleValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {tupleValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();
    }

}
