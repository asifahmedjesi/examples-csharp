namespace Examples;

/**
 * C# 9 introduced the record type which defines a reference type with value-based equality behavior.
 * Two record instances are equal if the values of all of their fields and properties are equal. 
 * This is different from classes, where two object variables are equal only if they refer to the same object, so-called reference equality.
 * 
 * They can be created in two different ways. 
 * 
 * A record can contain anything that a class can contain, but they are primarily used for encapsulating immutable data, which is data that cannot change once the object has been created. 
 * For this reason, they typically contain init-only properties to store their data as this maintains the immutability of the record.
 * 
 * First, in the same way as a class, but by using the record keyword instead.
 * 
 * The second way to create a record is using the so-called positional parameter form as shown in the following. 
 * When using this more concise syntax, the compiler will automatically generate the init-only properties as well as a constructor for those properties.
 * 
 * 
 * As of C# 10, it is possible to declare value type records using a record struct declaration. 
 * The reference type record may optionally be suffixed with the class keyword to clarify the difference between these two types.
 * 
 * The readonly keyword is included here to make the record struct immutable, because unlike record classes (reference type records) they are not immutable by default. 
 * Like record classes, a record struct may be defined with the standard property syntax, positional parameters, or a combination of both.
 * 
 * 
 * The record class is preferable when you want value-based equality and comparison, 
 * but want to use reference variables so as to not copy the values when passing the record object. 
 * 
 * In contrast, the record struct is useful when you want the features of records, including inheritance, 
 * but with value-based semantics similar to a struct with a small type that can be copied efficiently.
 * 
 */

internal class MyRecords
{
    public static void Run()
    {
        var examples = new MyRecords();

        examples.ObjectCreationExample();
        examples.EqualityExample();
        examples.InheritanceExample();        
        examples.CopyExample();
    }

    public void ObjectCreationExample()
    {
        var p1 = new PersonUsingFirstStyle { Name = "John", Age = 22 };
        var p2 = new PersonUsingSecondStyle("Sam", 20);

        var p3 = new PersonUsingMixedStyle("Eric", 15);
        var p4 = new PersonUsingMixedStyle("Elena", 27) { country = "Greece" };
    }

    public void EqualityExample()
    {
        var p1 = new Person("Jack", 30);
        var p2 = new Person("Jack", 30);

        bool b1 = p1.Equals(p2);    // true 
        bool b2 = (p1 == p2);       // true
        bool b3 = (p1 != p2);       // false

        Console.WriteLine($"b1: {b1}, b2: {b2}, b3: {b3}");
        Console.WriteLine();
    }

    public void InheritanceExample()
    {
        var s = new Student("Daryn", 30, "Math");
        Console.WriteLine(s);
        Console.WriteLine();
    }

    public void CopyExample() 
    {
        var s = new Student("Daryn", 30, "Math");
        var c1 = s with { }; // copy record 
        var c2 = s with { name = "Sara" }; // copy and alter record

        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine();
    }

    public void ConstructorExample()
    {
        var p1 = new Pet("Lucy"); // primary constructor 
        var p2 = new Pet(); // parameterless constructor 
        var p3 = new Employee("Jack") { age = 15 }; // constructor and initializer
    }
}

internal record PersonUsingFirstStyle
{
    public string Name { get; init; }
    public int Age { get; init; }
}

internal record PersonUsingSecondStyle(string name, int age);

internal record PersonUsingMixedStyle(string name, int age)
{
    public string? country { get; init; }
}


internal record Person(string name, int age);
internal record Student(string name, int age, string subject) : Person(name, age);


public readonly record struct Pet(string name); // value type immutable record (since readonly is used)
public record Fruit(string name);               // reference type record (immutable by default for this style)
public record class School(string name);        // reference type record (immutable by default for this style)

// Positional parameters and standard properties 
public readonly record struct Employee(string name)
{
    public int age { get; init; } = 0;
}