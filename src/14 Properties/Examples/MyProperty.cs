namespace Examples;

/**
 * Property
 * Read-only property
 * Write-only proeperty
 * Calculated property
 * Automatic property
 * Property initializers
 * Read-only auto-property with initializer
 * Private or Internal setter
 * Init-only setters
 * Expression-bodied property
 * Expression-bodied property read-only
 * init-only setters are permitted to modify readonly fields in their own class
 */

public class MyProperty
{
    public static void Run()
    {
        var stock = new Stock { FirstName = "HMM", LastName = "WOW", Pitch = 100 };

        // stock.Pitch = 100; // error: init property or indexer can only be assigned from object initializers.

        var note = new Note(pitch: 200, duration: 1000);

        Time t = new Time();
        t.Sec = 5;
        int s = t.Sec; // 5

        // t.Picoseconds = 10; // error: private set accessor
        int ps = t.Picoseconds;
    }
}

#region Property example

public class Stock
{

    // Property
    private decimal currentPrice;   // The private "backing" field
    public decimal CurrentPrice     // The public property
    {
        get { return currentPrice; }
        set { currentPrice = value; }
    }

    // Read-only property
    private decimal discount;
    public decimal Discount { get { return discount; } }

    // Write-only proeperty
    private decimal rate;
    public decimal Rate { set { rate = value; } }

    // Calculated property
    private decimal price, sharesOwned;
    public decimal Worth
    {
        get { return price * sharesOwned; }
    }        

    // Automatic property
    public decimal CurrentPriceValue { get; set; }

    // Property initializers
    public decimal PreviousPriceValue { get; set; } = 123;

    // Read-only auto-property with initializer
    public int Maximum { get; } = 999;

    // private or internal setter
    private decimal x;
    public decimal X
    {
        get { return x; }
        private set { x = Math.Round(value, 2); }
    }

    // Init-only setters
    public int Pitch { get; init; } = 20;       // “Init-only” property 
    public int Duration { get; init; } = 100;   // “Init-only” property

    // Expression-bodied property
    public decimal TotalWorth
    {
        get => currentPrice * sharesOwned;
        set => sharesOwned = value / currentPrice;
    }

    // Expression-bodied property read-only        
    public decimal NetWorth => currentPrice * sharesOwned;

    // Init-only setters are permitted to modify readonly fields in their own class
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string Name => $"{FirstName} {LastName}";

}

#endregion

#region Override property example

internal abstract class Shape
{
    public abstract double Area
    {
        get;
        set;
    }
}
internal class Square : Shape
{
    public double side;

    //constructor
    public Square(double s) => side = s;

    public override double Area
    {
        get => side * side;
        set => side = System.Math.Sqrt(value);
    }
}
internal class Cube : Shape
{
    public double side;

    //constructor
    public Cube(double s) => side = s;

    public override double Area
    {
        get => 6 * side * side;
        set => side = System.Math.Sqrt(value / 6);
    }
}

#endregion

#region Interface Properties

public interface IEmployee
{
    string Name { get; set; }
    int Counter { get; }
}
public class Employee : IEmployee
{
    public static int numberOfEmployees = 0;

    private string _name;
    public string Name  // read-write instance property
    {
        get => _name;
        set => _name = value;
    }

    private int _counter;
    public int Counter  // read-only instance property
    {
        get => _counter;        
    }

    //// constructor
    //public Employee() => this._counter = ++numberOfEmployees;
}

#endregion

public class Note
{
    public int Pitch { get; }
    public int Duration { get; }

    // Note: Notice that the _pixel field is read-only: init-only setters are permitted to modify readonly fields in their own class.
    readonly int _pixel;
    public int Pixel { get => _pixel; init => _pixel = value; }

    public Note(int pitch = 20, int duration = 100)
    {
        Pitch = pitch; Duration = duration;
    }

}

public class Time
{
    private int _seconds;
    public int Sec
    {
        get { return _seconds; }
        set
        {
            if (value > 0)
                _seconds = value;
            else
                _seconds = 0;
        }
    }


    private int _miliseconds;
    // Read-only property 
    public int Milisec
    {
        get { return _seconds; }
    }
    // Write-only property 
    public int Nanosec
    {
        set { _seconds = value; }
    }


    private int _picoseconds;
    public int Picoseconds
    {
        get { return _picoseconds; }
        private set { _picoseconds = value; }
    }


    // Auto-implemented Properties
    public int MiliSeconds { get; set; }

    // Read-only auto-property with initializer 
    public System.DateTime Created { get; } = System.DateTime.Now;

    public void Run()
    {
        Picoseconds = 10;
    }

}
