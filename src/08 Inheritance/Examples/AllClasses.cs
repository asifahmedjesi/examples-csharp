namespace Examples;

#region Inheritance Hierarchy

public class Asset
{
    public string Name;
    public virtual decimal Liability => 0; // Expression-bodied property
    public virtual Asset Clone() => new Asset { Name = Name };
}
public class Stock : Asset // inherits from Asset
{
    public long SharesOwned;
}
public class House : Asset // inherits from Asset
{
    public decimal Mortgage;
    public override decimal Liability => Mortgage;
    public override House Clone() => new House { Name = Name, Mortgage = Mortgage };
}

public class Fruit { }
public class Apple : Fruit { }
public class Banana : Fruit { }

#endregion

#region Hiding and Overriding

public class ParentClass
{
    public virtual void Foo() { Console.WriteLine("BaseClass.Foo"); }
}
public class Overrider : ParentClass
{
    public override void Foo() { Console.WriteLine("Overrider.Foo"); }
}
public class Nonhider : ParentClass
{
    public void Foo() { Console.WriteLine("Nonhider.Foo"); }
}
public class Hider : ParentClass
{
    public new void Foo() { Console.WriteLine("Hider.Foo"); }
}

#endregion

#region Sealed Keyword

public class MyInheritableBaseClass
{
    public virtual int NonOverridable() { return 1; }
}
public class MyInheritableClass : MyInheritableBaseClass
{
    public sealed override int NonOverridable() { return 5; }
}
sealed class MyNonInheritable { }

#endregion

#region Base Keyword

public class Rectangle
{
    public int x = 1;
    public int y = 10;
    public Rectangle(int a, int b) { x = a; y = b; }
    public virtual int GetArea() { return x * y; }
}
public class Square : Rectangle
{
    public Square(int a) : base(a, a) { }
}
public class Triangle : Rectangle
{
    public Triangle(int a, int b) : base(a, b) { }
    public override int GetArea() { return base.GetArea() / 2; }
}


public class Base { public Base(int a) { } }
// public class Derived : Base { } // compile-time error
public class Derived : Base { Derived(int a) : base(a) { } }

#endregion

#region Constructors and Inheritance

public class Baseclass
{
    public int X { get; }

    public Baseclass() { }
    public Baseclass(int x) => this.X = x;

    public virtual void Print() => Console.WriteLine($"Print From BaseClass: {this.X}");
    public virtual void Display() => Console.WriteLine($"Display From BaseClass: {this.X}");
}
// public class Subclass : Baseclass { }
// Subclass s = new Subclass(123); // error: Subclass does not contain a construction that takes 1 argument
public class Subclass : Baseclass
{
    public Subclass(int x) : base(x) { }

    public override void Print() => Console.WriteLine($"Print From Subclass: {this.X * 2}");
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Display From Subclass: {this.X * 2}");
    }
}


/** Implicit calling of the parameterless base-class constructor */
public class Baseclass2
{
    public int X;
    public Baseclass2() { X = 1; }
}
public class Subclass2 : Baseclass2
{
    public Subclass2() { Console.WriteLine(X); } // 1
}


public class Baseclass3
{
    public Baseclass3(int x, int y, int z, string s, DateTime d) { }
}
public class Subclass3 : Baseclass3
{
    public Subclass3(int x, int y, int z, string s, DateTime d) : base(x, y, z, s, d) { }
}

#endregion

#region Required members

public class University
{
    public required string Name;
}
public class School
{
    public required string Name;

    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public School(string n) => Name = n;
}

#endregion