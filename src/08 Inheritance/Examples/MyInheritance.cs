using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyInheritance
{
    public static void Run()
    {
        var examples = new MyInheritance();

        //examples.Inheritance();
        //examples.BoxingAndUnboxing();
        //examples.CastingAndReferenceConversions();
        //examples.The_as_Operator();
        //examples.The_is_Operator();
        //examples.VirtualMethod();
        //examples.HidingInheritedMembers();
        examples.BaseKeyword();
    }

    public void Inheritance()
    {
        Stock msft = new Stock
        {
            Name = "MSFT",
            SharesOwned = 1000000
        };
        Console.WriteLine(msft.Name); // MSFT 
        Console.WriteLine(msft.SharesOwned); // 1000

        House mansion = new House
        {
            Name = "Mansion",
            Mortgage = 250000
        };
        Console.WriteLine(mansion.Name); // Mansion 
        Console.WriteLine(mansion.Mortgage); // 250000

        Console.WriteLine();

        Display(msft);
        Display(mansion);

        Console.WriteLine();
    }

    public void InheritanceHierarchy()
    {
        Apple a = new Apple();
        Banana b = new Banana();

        Fruit f = a;
        Fruit g = b;

        Fruit newFruit = new Fruit();

        // a = (Apple)newFruit; // ERROR: InvalidCastException at runtime (Fruit is not an Apple)
    }

    public void CastingAndReferenceConversions()
    {
        /** Upcasting */
        Stock msft = new Stock();
        Asset a = msft; // Upcast

        Console.WriteLine(a == msft);   // True
        Console.WriteLine(a.Name);      // OK
        // Console.WriteLine(a.SharesOwned); // Compile-time error


        /** Downcasting */
        Stock s = (Stock)a; // Downcast
        Console.WriteLine(s.SharesOwned); // <No error> 
        Console.WriteLine(s == a); // True 
        Console.WriteLine(s == msft); // True


        House h = new House();
        Asset b = h; // Upcast always succeeds
        // Stock c = (Stock)b;  // Downcast fails: a is not a Stock.
        // System.InvalidCastException: Unable to cast object of type 'House' to type 'Stock'.

        Console.WriteLine();
    }

    public void The_as_Operator()
    {
        Asset a = new Asset();
        Stock s = a as Stock; // s is null; no exception thrown

        Console.WriteLine(s?.SharesOwned);
        if (s == null) Console.WriteLine("Conversion Failed");

        Console.WriteLine();
    }

    public void The_is_Operator()
    {
        Stock msft = new Stock { Name = "MSFT", SharesOwned = 50 };
        Asset a = msft; // Upcast

        if (a is Stock)
            Console.WriteLine(((Stock)a).SharesOwned);

        if (a is Stock s1)
            Console.WriteLine(s1.SharesOwned);

        if (a is Stock s2 && s2.SharesOwned > 100000)
            Console.WriteLine("Wealthy");
        else
            s2 = new Stock(); // s is in scope

        Console.WriteLine(s2.SharesOwned); // Still in scope

        Console.WriteLine();
    }

    public void VirtualMethod()
    {
        House mansion = new House { Name = "McMansion", Mortgage = 250000 };
        Asset a = mansion;
        Console.WriteLine(mansion.Liability);   // 250000 
        Console.WriteLine(a.Liability);         // 250000

        Console.WriteLine();
    }

    public void BaseKeyword()
    {
        Subclass obj = new Subclass(10);
        obj.Print(); // Print From Subclass: 10

        Baseclass baseclass = obj;
        baseclass.Print(); // Print From Subclass: 10

        obj.Display(); // Display From Subclass: 20
        baseclass.Display(); // Display From Baseclass: 10
    }

    public void BoxingAndUnboxing()
    {
        int i = 123;
        Console.WriteLine(i);   // 123

        object o = i;   // Boxing
        int j = (int)o; // Unboxing
        
        Console.WriteLine(j);   // 123

        Console.WriteLine();
    }

    public void HidingInheritedMembers()
    {
        Overrider over = new Overrider();
        ParentClass b1 = over;
        over.Foo(); // Child: Overrider.Foo
        b1.Foo();   // Parent: Overrider.Foo

        Nonhider nh = new Nonhider();
        ParentClass b2 = nh;
        nh.Foo(); // Child: Nonhider.Foo
        b2.Foo(); // Parent: BaseClass.Foo

        Hider h = new Hider();
        ParentClass b3 = h;
        h.Foo();    // Hider.Foo
        b3.Foo();   // BaseClass.Foo

        Console.WriteLine();
    }

    public void RequiredParameters()
    {
        var uni1 = new University { Name = "NSU" };
        // var uni2 = new University(); // Error: will not compile!

        var school = new School("Arab Mission");

        Console.WriteLine();
    }

    public void Display(Asset asset)
    {
        System.Console.WriteLine(asset.Name);
    }
}

