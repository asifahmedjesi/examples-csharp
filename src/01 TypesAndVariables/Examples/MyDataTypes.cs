using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyDataTypes
{
    public static void Run()
    {
        var example = new MyDataTypes();

        example.DisplayDataTypes();
        Console.WriteLine();
    }

    public void DisplayDataTypes()
    {
        Console.WriteLine("## Data Types:");
        Console.WriteLine();

        // Integer Types
        var sbyteValue = (sbyte)1;
        var byteValue = (byte)1;
        var shortValue = (short)1;
        var ushortValue = (ushort)1;
        var intValue = 1;
        var uintValue = 1U;
        var longValue = 1L;
        var ulongValue = 1UL;

        Console.WriteLine("Integer Types:");
        Console.WriteLine($"sbyteValue: {sbyteValue}, TypeName {sbyteValue.GetType().Name}, TypeFullName {sbyteValue.GetType().FullName}, BaseTypeFullName {sbyteValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {sbyteValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"byteValue: {byteValue}, TypeName {byteValue.GetType().Name}, TypeFullName {byteValue.GetType().FullName}, BaseTypeFullName {byteValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {byteValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"shortValue: {shortValue}, TypeName {shortValue.GetType().Name}, TypeFullName {shortValue.GetType().FullName}, BaseTypeFullName {shortValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {shortValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"ushortValue: {ushortValue}, TypeName {ushortValue.GetType().Name}, TypeFullName {ushortValue.GetType().FullName}, BaseTypeFullName {ushortValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {ushortValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"intValue: {intValue}, TypeName {intValue.GetType().Name}, TypeFullName {intValue.GetType().FullName}, BaseTypeFullName {intValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {intValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"uintValue: {uintValue}, TypeName {uintValue.GetType().Name}, TypeFullName {uintValue.GetType().FullName}, BaseTypeFullName {uintValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {uintValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"longValue: {longValue}, TypeName {longValue.GetType().Name}, TypeFullName {longValue.GetType().FullName}, BaseTypeFullName {longValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {longValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"ulongValue: {ulongValue}, TypeName {ulongValue.GetType().Name}, TypeFullName {ulongValue.GetType().FullName}, BaseTypeFullName {ulongValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {ulongValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Floating-point Types        
        float floatValue = 3.14F;
        double doubleValue = 3.14;
        double doubleValueWithSuffix = 3.14D;
        decimal decimalValue = 3.14M;

        Console.WriteLine("Floating-Point Types:");
        Console.WriteLine($"floatValue: {floatValue}, TypeName {floatValue.GetType().Name}, TypeFullName {floatValue.GetType().FullName}, BaseTypeFullName {floatValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {floatValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"doubleValue: {doubleValue}, TypeName {doubleValue.GetType().Name}, TypeFullName {doubleValue.GetType().FullName}, BaseTypeFullName {doubleValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {doubleValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"doubleValueWithSuffix: {doubleValueWithSuffix}, TypeName {doubleValueWithSuffix.GetType().Name}, TypeFullName {doubleValueWithSuffix.GetType().FullName}, BaseTypeFullName {doubleValueWithSuffix.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {doubleValueWithSuffix.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"decimalValue: {decimalValue}, TypeName {decimalValue.GetType().Name}, TypeFullName {decimalValue.GetType().FullName}, BaseTypeFullName {decimalValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {decimalValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Character and String Types
        char charValue = 'A';
        string stringValue = "Hello C#!";

        Console.WriteLine("Character and String Types:");
        Console.WriteLine($"charValue: {charValue}, TypeName {charValue.GetType().Name}, TypeFullName {charValue.GetType().FullName}, BaseTypeFullName {charValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {charValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"stringValue: {stringValue}, TypeName {stringValue.GetType().Name}, TypeFullName {stringValue.GetType().FullName}, BaseTypeFullName {stringValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {stringValue.GetType().BaseType?.BaseType?.FullName ?? "NONE"}");
        Console.WriteLine();

        // Boolean Types
        bool trueLiteral = true;
        bool falseLiteral = false;

        Console.WriteLine("Boolean Types:");
        Console.WriteLine($"trueLiteral: {trueLiteral}, TypeName {trueLiteral.GetType().Name}, TypeFullName {trueLiteral.GetType().FullName}, BaseTypeFullName {trueLiteral.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {trueLiteral.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"falseLiteral: {falseLiteral}, TypeName {falseLiteral.GetType().Name}, TypeFullName {falseLiteral.GetType().FullName}, BaseTypeFullName {falseLiteral.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {falseLiteral.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Object Type
        Console.WriteLine("Object Type:");
        object objValue = new object();
        
        Console.WriteLine($"objValue: {objValue}, TypeName {objValue.GetType().Name}, TypeFullName {objValue.GetType().FullName}, BaseTypeFullName {objValue.GetType().BaseType?.FullName ?? "NONE"}, BaseTypeBaseTypeFullName {objValue.GetType().BaseType?.BaseType?.FullName ?? "NONE"}");
        Console.WriteLine();

        // Array Type
        Console.WriteLine("Array Type:");
        int[] arrayIntValue = new int[] { 1, 2, 3 };
        string[] arrayStringValue = new string[] { "A", "B", "C" };

        Console.WriteLine($"arrayIntValue: [{string.Join(", ", arrayIntValue)}], TypeName {arrayIntValue.GetType().Name}, TypeFullName {arrayIntValue.GetType().FullName}, BaseTypeFullName {arrayIntValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {arrayIntValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine($"arrayStringValue: [{string.Join(", ", arrayStringValue)}], TypeName {arrayStringValue.GetType().Name}, TypeFullName {arrayStringValue.GetType().FullName}, BaseTypeFullName {arrayStringValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {arrayStringValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Struct Type
        Console.WriteLine("Struct Type:");
        DateTime dateTimeValue = DateTime.Now;
        Console.WriteLine($"dateTimeValue: {dateTimeValue}, TypeName {dateTimeValue.GetType().Name}, TypeFullName {dateTimeValue.GetType().FullName}, BaseTypeFullName {dateTimeValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {dateTimeValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Enum Type
        Console.WriteLine("Enum Type:");
        DayOfWeek dayOfWeekValue = DayOfWeek.Monday;
        Console.WriteLine($"dayOfWeekValue: {dayOfWeekValue}, TypeName {dayOfWeekValue.GetType().Name}, TypeFullName {dayOfWeekValue.GetType().FullName}, BaseTypeFullName {dayOfWeekValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {dayOfWeekValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Record Type
        Console.WriteLine("Record Type:");
        var myRecord = new PersonRecord("John", "Doe");
        Console.WriteLine($"myRecord: {myRecord}, TypeName {myRecord.GetType().Name}, TypeFullName {myRecord.GetType().FullName}, BaseTypeFullName {myRecord.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {myRecord.GetType().BaseType?.BaseType?.FullName ?? "NONE"}");
        Console.WriteLine();

        // Class Type
        Console.WriteLine("Class Type:");
        var myStringBuilder = new StringBuilder("Hello");
        Console.WriteLine($"myStringBuilder: {myStringBuilder}, TypeName {myStringBuilder.GetType().Name}, TypeFullName {myStringBuilder.GetType().FullName}, BaseTypeFullName {myStringBuilder.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {myStringBuilder.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Interface Type
        Console.WriteLine("Interface Type:");
        IEnumerable<int> myEnumerable = new List<int> { 1, 2, 3 };
        Console.WriteLine($"myEnumerable: {myEnumerable}, TypeName {myEnumerable.GetType().Name}, TypeFullName {myEnumerable.GetType().FullName}, BaseTypeFullName {myEnumerable.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {myEnumerable.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Delegate Type
        Console.WriteLine("Delegate Type:");
        Action myAction = () => Console.WriteLine("Hello from delegate!");
        Console.WriteLine($"myAction: {myAction}, TypeName {myAction.GetType().Name}, TypeFullName {myAction.GetType().FullName}, BaseTypeFullName {myAction.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {myAction.GetType().BaseType?.BaseType?.FullName}, , BaseTypeBaseTypeBaseTypeFullName {myAction.GetType().BaseType?.BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Nullable Value Type
        Console.WriteLine("Nullable Value Type:");
        int? nullableIntValue = 42;
        Console.WriteLine($"nullableIntValue: {nullableIntValue.Value}, TypeName {nullableIntValue.GetType().Name}, TypeFullName {nullableIntValue.GetType().FullName}, BaseTypeFullName {nullableIntValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {nullableIntValue.GetType().BaseType?.BaseType?.FullName}");
        Console.WriteLine();

        // Nullable Reference Type
        Console.WriteLine("Nullable Reference Type:");
        string? nullableStringValue = "Hello, Nullable!";
        Console.WriteLine($"nullableStringValue: {nullableStringValue}, TypeName {nullableStringValue.GetType().Name}, TypeFullName {nullableStringValue.GetType().FullName}, BaseTypeFullName {nullableStringValue.GetType().BaseType?.FullName}, BaseTypeBaseTypeFullName {nullableStringValue.GetType().BaseType?.BaseType?.FullName ?? "NONE"}");
        Console.WriteLine();
    }
}

public record PersonRecord(string FirstName, string LastName);
