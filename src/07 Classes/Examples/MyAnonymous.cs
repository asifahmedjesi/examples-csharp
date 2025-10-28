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
}
