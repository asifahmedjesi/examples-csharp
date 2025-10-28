using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyRanges
{
    public static void Run()
    {
        
    }

    public void ExampleWithArray()
    {
        int[] b = { 1, 2, 3, 4, 5 };
        foreach (int n in b[1..3])
        {
            System.Console.Write(n);    // "23"
        }

        System.Range range = 0..3;      // 1st to 3rd 
        foreach (int n in b[range])
        {
            System.Console.Write(n);    // "123"
        }
    }

    public void ExampleWithString()
    {
        string s = "welcome";

        System.Index first = 0;
        System.Index last = ^1;

        System.Console.WriteLine($"{s[first]}, {s[last]}"); // "w, e"
        System.Console.WriteLine(s[^4..]); // "come"
    }
}
