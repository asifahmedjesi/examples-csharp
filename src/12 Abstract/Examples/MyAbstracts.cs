using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;
internal class MyAbstracts
{

}

public abstract class ShapeBase
{
    public int x = 100, y = 100;

    // Abstract method
    public abstract int GetArea();

    // Abstract property
    public abstract int area { get; set; }

    // Abstract indexer
    public abstract int this[int index] { get; set; }

    // Abstract delegate
    public delegate void MyDelegate();

    // Abstract event
    public abstract event MyDelegate MyEvent;

    // Abstract class
    public abstract class InnerShape { };
}


public abstract class Shape
{
    public int x = 100, y = 100;
    public abstract int GetArea();
}
public class Rectangle : Shape
{
    public override int GetArea() { return x * y; }
}
public abstract class Square : Shape { }


public class NonAbstract { }
public abstract class Abstract : NonAbstract { }


public class MyClass
{
    public virtual void Dummy() { }
}
public abstract class MyAbstract : MyClass
{
    public abstract override void Dummy();
}


// Defines default functionality and definitions 
public abstract class MyShape
{
    public int x = 100, y = 100;
    public abstract int GetArea();
}
// class MyRectangle is a MyShape
public class MyRectangle : MyShape
{
    public override int GetArea()
    {
        throw new NotImplementedException();
    }
}


// Defines an interface or a specific functionality 
public interface IComparable
{
    int Compare(object o);
}
// class can be compared
public class MyAnotherClass : IComparable
{
    public int Compare(object o)
    {
        throw new NotImplementedException();
    }
}
