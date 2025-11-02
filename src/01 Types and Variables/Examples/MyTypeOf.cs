using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

public class MyTypeOf
{
    public static void Run()
    {
        object b = new Giraffe();

        Console.WriteLine(typeof(Giraffe)); // output: MyCSharp.Giraffe
        Console.WriteLine(b.GetType());     // output: MyCSharp.Giraffe    

        Console.WriteLine(typeof(Animal));  // output: MyCSharp.Animal


        Console.WriteLine(b is Animal);  // output: True
        Console.WriteLine(b.GetType() == typeof(Animal));  // output: False

        Console.WriteLine(b is Giraffe);  // output: True
        Console.WriteLine(b.GetType() == typeof(Giraffe));  // output: True

        Console.WriteLine($"nameof(Animal): {nameof(Animal)}");
    }
}

public class Animal { }

public class Giraffe : Animal { }