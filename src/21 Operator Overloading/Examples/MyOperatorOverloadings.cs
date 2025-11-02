namespace Examples;

/**
 * 
 * Note that for an operator overloading method to work, it must be defined as both public and static.
 * 
 * Overloadable Operators:
 * 
 * Binary Operators,
 *      + - * / %  
 *      (+= -= *= /= %=)
 *      & | ^ << >>  
 *      (&= |= ^= <<= >>=)
 *      == != > < >= <=
 *      
 * Unary Operators,
 *      + - ! ~ ++ --  
 *      true false
 *      
 * Not Overloadable,
 *      && || = . [ ] ( ) :: 
 *      ?: ?? -> => new as is 
 *      sizeof typeof nameof
 * 
 */

internal class MyOperatorOverloadings
{
    public static void Run()
    {
        MyNum a = new MyNum(10);
        MyNum b = new MyNum(5);
        
        MyNum c = MyNum.Add(a, b);
        MyNum d = a + b; // Using the overloaded operator        

        Console.WriteLine($"a.val = {a.val}");
        Console.WriteLine($"c.val = {c.val}");
        Console.WriteLine($"d.val = {d.val}");

        a++; // Using the overloaded unary operator
        Console.WriteLine($"a.val = {a.val}");

        ++a; // Using the overloaded unary operator again
        Console.WriteLine($"a.val = {a.val}");

        a = a + 10; // Using the overloaded operator with an int
        Console.WriteLine($"a.val = {a.val}");

        if (a) // Uses the overloaded true operator
        {
            Console.WriteLine("a is TRUE");
        }
        else
        {
            Console.WriteLine("a is FALSE");
        }
    }
}

internal class MyNum
{
    public int val;
    public MyNum(int i) { val = i; }

    /** 
     * Two MyNumber instances can be added together using the Add method.
     */
    public static MyNum Add(MyNum a, MyNum b)
    {
        return new MyNum(a.val + b.val);
    }

    /** 
     * Binary Operator Overloading 
     */
    public static MyNum operator +(MyNum a, MyNum b)
    {
        return new MyNum(a.val + b.val);
    }

    /** 
     * Unary Operator Overloading 
     */
    public static MyNum operator ++(MyNum a)
    {
        return new MyNum(a.val + 1);
    }

    /** 
     * Return Types and Parameters 
     * When overloading a unary operator, the return type and parameter type must be of the enclosing type.
     */
    public static MyNum operator +(MyNum a, int b)
    {
        return new MyNum(a.val + b);
    }

    /** 
     * True and False Operator Overloading 
     */
    public static bool operator true(MyNum a)
    {
        return (a.val != 0);
    }
    public static bool operator false(MyNum a)
    {
        return (a.val == 0);
    }
}