using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyAnonymous
{
    public static void Run()
    {
        var person = new { Name = "John", Age = 30 };
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        var book = new { Title = "C# Programming", Author = "Jane Doe", Pages = 500 };
        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Pages: {book.Pages}");

        var v = new { first = 1, second = true };
        Console.WriteLine($"First: {v.first}, Second: {v.second}");
    }   

    public void Example()
    {
        var person = new { Name = "John", Age = 30 };
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        int Age = 23;
        var dude = new { Name = "Bob", Age, Age.ToString().Length };

        // Anonymous types are immutable
        // person.Name = "Doe"; // This will cause a compile-time error

        // Anonymous types can be used in LINQ queries
        var people = new[]
        {
            new { Name = "Alice", Age = 25 },
            new { Name = "Bob", Age = 35 }
        };
        foreach (var p in people)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }

        Console.WriteLine();
    }
}
