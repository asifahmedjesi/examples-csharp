using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyTuples
{
    public static void Run()
    {
        // Creating a tuple without named elements
        var bob = ("Bob", 23); // Allow compiler to infer the element types
        Console.WriteLine(bob.Item1); // Bob 
        Console.WriteLine(bob.Item2); // 23

        // Creating a tuple with named elements
        var person = (Name: "Alice", Age: 30);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        // Deconstructing a tuple
        var (name, age) = person;
        Console.WriteLine($"Name: {name}, Age: {age}");

        // Tuples can be nested
        var nestedTuple = (Person: person, City: "New York");
        Console.WriteLine($"Name: {nestedTuple.Person.Name}, City: {nestedTuple.City}");

        // Tuples can be used in methods
        (string, int) personInfo = GetPerson(); // Could use 'var' instead if we want 
        Console.WriteLine(personInfo.Item1);    // Bob
        Console.WriteLine(personInfo.Item2);    // 23

        (string, int) personInfo2 = GetPerson2();
        Console.WriteLine(personInfo2.Item1);    // Rob
        Console.WriteLine(personInfo2.Item2);    // 24

        var (personName, personAge) = GetPerson2();
        Console.WriteLine($"personName: {personName}"); // Rob
        Console.WriteLine($"personAge: {personAge}");   // 24


        (string, int) GetPerson() => ("Bob", 23);
        (string name, int age) GetPerson2() => ("Rob", 24);


        var now = DateTime.Now;
        var tuple = (now.Day, now.Month, now.Year);
        Console.WriteLine(tuple.Day); // OK


        // ValueTuple.Create
        ValueTuple<string, int> bob1 = ValueTuple.Create("Bob", 23);
        (string, int) bob2 = ValueTuple.Create("Bob", 23);
        (string name, int age) bob3 = ValueTuple.Create("Bob", 23);


        // Deconstructing Tuples
        var bob4 = ("Bob", 23);
        (string name2, int age2) = bob4;    // Deconstruct the bob tuple into, separate variables (name and age).
        Console.WriteLine(name2);
        Console.WriteLine(age2);


        var t1 = ("one", 1);
        var t2 = ("one", 1);
        Console.WriteLine(t1.Equals(t2)); // True


        Tuple<string, int> t = Tuple.Create("Bob", 23); // Factory method 
        Console.WriteLine(t.Item1); // Bob
        Console.WriteLine(t.Item2); // 23
    }
}
