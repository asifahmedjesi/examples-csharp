namespace Examples;

public class MyConstructorVisibility
{
    public static void Run()
    {
        Console.WriteLine("CONSTRUCTOR VISIBILITY");
        Console.WriteLine("");

        /** Public constructor */
        var bicycle = new Bicycle();

        /** Private constructor */
        var car = Car.Create();

        /** Internal constructor */
        var truck = new Truck();

        /** Protected constructor */
        // var bus = new Bus();
        // ERROR: 'Bus.Bus()' is inaccessible due to its 'protected' protection level

        var microBus = new MicroBus();

        /** Private protected constructor */
        // var motorcycle = new Motorcycle();
        // ERROR: 'Motorcycle.Motorcycle()' is inaccessible due to its 'private protected' protection level

        var hondaMotorcycle = new HondaMorotcycle();

        /** Protected internal constructor */
        var scooter = new Scooter();

        Console.WriteLine();
    }
}

public class Bicycle
{
    public Bicycle() { }
}

public class Car
{
    private Car() { }
    public static Car Create() => new();
}

public class Truck
{
    internal Truck() { }    
}

public class Bus
{
    protected Bus() 
    {
        Console.WriteLine("Base class 'Bus.Bus()' protected constructor called.");
    }
}

public class MicroBus : Bus
{
    public MicroBus() : base() 
    {
        Console.WriteLine("Derived class 'MicroBus.MicroBus()' public constructor called.");
    }

    public void Test()
    {
        // var bus = new Bus(); // ERROR: 'Bus.Bus()' is inaccessible due to its 'protected' protection level
    }
}

public class Motorcycle
{
    private protected Motorcycle() 
    {
        Console.WriteLine("Base class 'Motorcycle.Motorcycle()' private protected constructor called.");
    }
}

public class HondaMorotcycle : Motorcycle
{
    public HondaMorotcycle() : base() 
    {
        Console.WriteLine("Derived class 'HondaMorotcycle.HondaMorotcycle()' public constructor called.");
    }

    public void Test()
    {
        // Motorcycle moto = new Motorcycle();  // ERROR: 'Motorcycle.Motorcycle()' is inaccessible due to its 'private protected' protection level
    }
}

public class Scooter
{
    protected internal Scooter() { }
}

public class Counter
{
    private Counter() { }

    public static int currentCount;

    public static int IncrementCount()
    {
        return ++currentCount;
    }
}
