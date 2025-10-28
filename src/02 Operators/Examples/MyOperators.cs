using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyOperators
{
    public static void Run()
    {
        var example = new MyOperators();
        Console.WriteLine();

        example.ArithmeticOperators();
        example.AssignmentOperators();
        example.IncrementDecrementOperators();
        example.ComparisonOperators();
        example.LogicalOperators();
        example.BitwiseOperators();
        example.BitwiseAssignmentOperators();
        example.OperatorPrecedence();
        example.ConditionalOperator();
        example.NullCoalescingOperator();
        example.NullCoalescingAssignmentOperator();
        example.NullConditionalOperator();
        example.NullConditionalAndNullCoalescingOperators();
        example.NameOfOperator();
        example.TypeOfOperator();
    }

    public void OperatorPrecedence()
    {
        Console.WriteLine("Operator Precedence");

        bool x = 2 + 3 > 1 * 4 && 5 / 5 == 1; // true
        Console.WriteLine($"Operator Precedence Example: {x}"); // true

        bool z = ((2 + 3) > (1 * 4)) && ((5 / 5) == 1); // true
        Console.WriteLine($"Operator Precedence Example with Parentheses: {z}"); // true

        Console.WriteLine();
    }

    public void ConditionalOperator()
    {
        Console.WriteLine("Conditional Operator (Ternary Operator)");

        int x = 10;
        int y = 20;
        int max = (x > y) ? x : y;
        Console.WriteLine($"Max of {x} and {y} is: {max}");

        string s = "Hello, World!";
        int characterCount = s is null ? 0 : s.Length;
        Console.WriteLine($"Character count in string: {characterCount}");

        Console.WriteLine();
    }

    public void NullCoalescingOperator()
    {
        Console.WriteLine("Null Coalescing Operator (??)");

        // The null coalescing operator (??) returns the left-hand operand if it is not null; otherwise, it returns the right-hand operand.

        string s = null;

        string result = s ?? "Default Value";
        Console.WriteLine($"Result using Null Coalescing Operator with null value: {result}");

        s = "Hello, World!";
        result = s ?? "Default Value";
        Console.WriteLine($"Result using Null Coalescing Operator with non-null value: {result}");

        Console.WriteLine();
    }

    public void NullConditionalOperator()
    {
        Console.WriteLine("Null Conditional Operator (?.)");

        // The null-conditional operator can be used with the commonly used type members that we describe in “Classes”, including methods, fields, properties, and indexers.

        System.Text.StringBuilder sb = null;

        string s1 = sb?.ToString(); // No error; s is null
        // Equivalent to:
        // string s1 = (sb == null ? null : sb.ToString());

        string[] words = null;
        string word = words?[1]; // word is null

        string s2 = sb?.ToString().ToUpper(); // No error

        // int length = sb?.ToString().Length; // Illegal
        int? length = sb?.ToString().Length; // OK : int? can be null

        Console.WriteLine();
    }

    public void NullCoalescingAssignmentOperator()
    {
        Console.WriteLine("Null Coalescing Assignment Operator (??=)");

        // The null coalescing assignment operator (??=) assigns the right-hand operand to the left-hand operand only if the left-hand operand is null.

        string? nullableString = null;

        // Using null coalescing assignment operator
        nullableString ??= "Assigned Value";
        Console.WriteLine($"Value after Null Coalescing Assignment: {nullableString}");

        nullableString ??= "This will not be assigned";
        Console.WriteLine($"Value after trying to assign again: {nullableString}");

        Console.WriteLine();
    }

    public void NullConditionalAndNullCoalescingOperators()
    {
        Console.WriteLine("Null Conditional and Null Coalescing Operators");

        // Null conditional operator (?.) allows you to access members and elements only when the operand is not null.

        string? nullableString = null;

        // Using null conditional operator
        int? length = nullableString?.Length; // This will be null if nullableString is null
        Console.WriteLine($"Length of nullableString using null conditional operator: {length}");

        // Using null coalescing operator
        int lengthOrDefault = nullableString?.Length ?? 0; // If nullableString is null, it defaults to 0
        Console.WriteLine($"Length of nullableString using null conditional and null coalescing operator: {lengthOrDefault}");

        Console.WriteLine();
    }

    public void ArithmeticOperators()
    {
        Console.WriteLine("Arithmetic Operators");

        int a = 10;
        int b = 20;

        Console.WriteLine($"Initial Values: a = {a}, b = {b}");
        Console.WriteLine($"Addition: {a + b}");
        Console.WriteLine($"Subtraction: {a - b}");
        Console.WriteLine($"Multiplication: {a * b}");
        Console.WriteLine($"Division: {b / a}");
        Console.WriteLine($"Modulus: {b % a}");


        float x = 3 + 2;    // 5 // addition
        Console.WriteLine($"Float Addition: {x}");

        x = 3 - 2;      // 1 // subtraction
        Console.WriteLine($"Float Subtraction: {x}");

        x = 3 * 2;      // 6 // multiplication
        Console.WriteLine($"Float Multiplication: {x}");

        x = 3 / 2;      // 1 // division
        Console.WriteLine($"Float Division: {x}");

        x = 3 % 2;      // 1 // modulus (division remainder)
        Console.WriteLine($"Float Modulus: {x}");

        x = 3 / (float)2;   // 1.5
        Console.WriteLine($"Float Division with Float Result: {x}");

        Console.WriteLine();
    }

    public void AssignmentOperators()
    {
        Console.WriteLine("Assignment Operators");

        int x = 0;
        Console.WriteLine($"Initial Value: {x}");

        x += 5; // x = x + 5;
        Console.WriteLine($"After Addition Assignment (x += 5): {x}");

        x -= 5; // x = x - 5; 
        Console.WriteLine($"After Subtraction Assignment (x -= 5): {x}");

        x *= 5; // x = x * 5; 
        Console.WriteLine($"After Multiplication Assignment (x *= 5): {x}");

        x /= 5; // x = x / 5; 
        Console.WriteLine($"After Division Assignment (x /= 5): {x}");

        x %= 5; // x = x % 5;
        Console.WriteLine($"After Modulus Assignment (x %= 5): {x}");

        Console.WriteLine();
    }

    public void IncrementDecrementOperators()
    {
        Console.WriteLine("Increment and Decrement Operators");

        int a = 5;
        Console.WriteLine($"Initial Value (a): {a}");

        a++; // post-increment  : a = a+1;
        Console.WriteLine($"Post-increment (a++): {a}");

        a--; // post-decrement  : a = a-1;
        Console.WriteLine($"Post-decrement (a--): {a}");

        ++a; // pre-increment   : a = a+1;
        Console.WriteLine($"Pre-increment (++a): {a}");

        --a; // pre-decrement   : a = a-1;
        Console.WriteLine($"Pre-decrement (--a): {a}");


        int x, y;

        x = 5;
        Console.WriteLine($"Initial Value (x): {x}");

        y = x++; // y=5, x=6 
        Console.WriteLine($"Post-increment (x++): x={x}, y={y}");

        x = 5;
        y = ++x; // y=6, x=6
        Console.WriteLine($"Pre-increment (++x): x={x}, y={y}");

        Console.WriteLine();
    }

    public void ComparisonOperators()
    {
        Console.WriteLine("Comparison Operators");

        bool b = (2 == 3); // equal to (false)
        Console.WriteLine($"Is 2 equal to 3? {b}");

        b = (2 != 3); // not equal to (true)
        Console.WriteLine($"Is 2 not equal to 3? {b}");

        b = (2 > 3);  // greater than (false)
        Console.WriteLine($"Is 2 greater than 3? {b}");

        b = (2 < 3);  // less than (true)
        Console.WriteLine($"Is 2 less than 3? {b}");

        b = (2 >= 3); // greater than or equal to (false) 
        Console.WriteLine($"Is 2 greater than or equal to 3? {b}");

        b = (2 <= 3); // less than or equal to (true)
        Console.WriteLine($"Is 2 less than or equal to 3? {b}");

        Console.WriteLine();
    }

    public void LogicalOperators()
    {
        Console.WriteLine("Logical Operators");

        bool a = true;
        bool b = false;

        Console.WriteLine($"Initial Values: a = {a}, b = {b}");
        Console.WriteLine($"Logical AND: {a && b}");
        Console.WriteLine($"Logical OR: {a || b}");
        Console.WriteLine($"Logical NOT: {!a}");

        Console.WriteLine();
    }

    public void BitwiseOperators()
    {
        Console.WriteLine("Bitwise Operators");

        int x = 5;  // 0101 in binary
        int y = 3;  // 0011 in binary

        Console.WriteLine($"Initial Values: x = {x}, y = {y}");
        Console.WriteLine($"Bitwise AND: {x & y}");         // 0001 in binary (1 in decimal)
        Console.WriteLine($"Bitwise OR: {x | y}");          // 0111 in binary (7 in decimal)
        Console.WriteLine($"Bitwise XOR: {x ^ y}");         // 0110 in binary (6 in decimal)
        Console.WriteLine($"Bitwise NOT of x: {~x}");       // Inverts bits of x
        Console.WriteLine($"Left Shift x by 1: {x << 1}");  // 1010 in binary (10 in decimal)
        Console.WriteLine($"Right Shift x by 1: {x >> 1}"); // 0010 in binary (2 in decimal)

        int z = 5 & 4;  // and (0b101 & 0b100 = 0b100 = 4)
        Console.WriteLine($"and (0b101 & 0b100 = 0b100 = 4): {z}");

        z = 5 | 4;  // or (0b101 | 0b100 = 0b101 = 5)
        Console.WriteLine($"or (0b101 | 0b100 = 0b101 = 5): {z}");

        z = 5 ^ 4;  // xor (0b101 ^ 0b100 = 0b001 = 1)
        Console.WriteLine($"xor (0b101 ^ 0b100 = 0b001 = 1): {z}");

        z = 4 << 1; // left shift (0b100 << 1 = 0b1000 = 8)
        Console.WriteLine($"left shift (0b100 << 1 = 0b1000 = 8): {z}");

        z = 4 >> 1; // right shift (0b100 >> 1 = 0b10 = 2)
        Console.WriteLine($"right shift (0b100 >> 1 = 0b10 = 2): {z}");

        z = ~4;     // invert (~0b00000100 = 0b11111011 = -5)
        Console.WriteLine($"invert (~0b00000100 = 0b11111011 = -5): {z}");

        Console.WriteLine();
    }

    public void BitwiseAssignmentOperators()
    {
        Console.WriteLine("Bitwise Assignment Operators");

        int x = 5;  // 0101 in binary
        Console.WriteLine($"Initial Value: x = {x}");

        x &= 3; // x = x & 3; // 0001 in binary (1 in decimal)
        Console.WriteLine($"After Bitwise AND Assignment (x &= 3): {x}");

        x = 5; // Reset x
        x |= 3; // x = x | 3; // 0111 in binary (7 in decimal)        
        Console.WriteLine($"After Bitwise OR Assignment (x |= 3): {x}");

        x = 5; // Reset x        
        x ^= 3; // x = x ^ 3; // 0110 in binary (6 in decimal)
        Console.WriteLine($"After Bitwise XOR Assignment (x ^= 3): {x}");


        int z = 5;
        Console.WriteLine("Initial Value: z = " + z);

        z &= 4;  // and (0b101 & 0b100 = 0b100 = 4)
        Console.WriteLine($"After Bitwise AND Assignment (z &= 4): {z}"); // 4

        z = 5;
        z |= 4;  // or (0b101 | 0b100 = 0b101 = 5)
        Console.WriteLine($"After Bitwise OR Assignment (z |= 4): {z}"); // 5

        z = 5;
        z ^= 4;  // xor (0b101 ^ 0b100 = 0b001 = 1)
        Console.WriteLine($"After Bitwise XOR Assignment (z ^= 4): {z}"); // 1

        z = 5;
        z <<= 1; // left shift (0b101 << 1 = 0b1010 = 10) 
        Console.WriteLine($"After Left Shift Assignment (z <<= 1): {z}"); // 10

        z = 5;
        z >>= 1; // right shift (0b101 >> 1 = 0b10 = 2)
        Console.WriteLine($"After Right Shift Assignment (z >>= 1): {z}"); // 2

        Console.WriteLine();
    }

    public void NameOfOperator()
    {
        int count = 123;
        string name = nameof(count); // name is "count"
        Console.WriteLine(name);

        name = nameof(StringBuilder.Length);
        Console.WriteLine(name);

        name = nameof(StringBuilder) + "." + nameof(StringBuilder.Length);
        Console.WriteLine(name);
    }

    public void TypeOfOperator()
    {
        Type t = typeof(int);     
        Console.WriteLine(t.FullName); // System.Int32
        
        t = typeof(System.Collections.Generic.List<string>);
        Console.WriteLine(t.FullName); // System.Collections.Generic.List`1[System.String]
    }
}
