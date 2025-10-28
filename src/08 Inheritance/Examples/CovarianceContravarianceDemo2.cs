namespace Examples;

/**
 * Covariance and contravariance support for method groups allows for matching method signatures with delegate types. 
 * 
 * This enables you to assign to delegates not only 
 *      - methods that have matching signatures, 
 *      - but also methods that return more derived types (covariance) or 
 *      - that accept parameters that have less derived types (contravariance) than that specified by the delegate type. 
 * 
 * 
 * Base class reference can hold a derived class object BUT not vice-versa.
 * Covariance: Covariance lets you to pass a derived type object where a base type object is expected Covariance can be applied on delegate, generic, array, interface, etc.
 * Contravariance: Contravariance is applied to parameters. It allows a method with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class
 * 
 * 
 * Covariance allows a "bigger" (less specific) type to be substituted in an API where the original type is only used in an "output" position (e.g. as a return value). 
 * Contravariance allows a "smaller" (more specific) type to be substituted in an API where the original type is only used in an "input" position.
 * 
 */

public class Dog { public string Name { get; set; } }
public class Poodle : Dog { public void DoBackflip() { System.Console.WriteLine("2nd smartest breed - woof!"); } }

internal class CovarianceContravarianceDemo2
{
    /// TOutput represents covariance where a method returns a more specific type.
    /// TInput represents contravariance where a method is passed a less specific type.
    delegate TOutput Converter<in TInput, out TOutput>(TInput input);

    public static void Run()
    {
        var examples = new CovarianceContravarianceDemo2();
        
        examples.Contravariance();
        examples.Contravariance();
    }

    public static Poodle ConvertDogToPoodle(Dog dog)
    {
        return new Poodle() { Name = dog.Name };
    }

    public void Example1()
    {
        // Contravariance: method accepts less derived type (Dog)
        Converter<Dog, Poodle> dogToPoodleConverter = ConvertDogToPoodle;
        Dog myDog = new Dog() { Name = "Fido" };
        
        Poodle myPoodle = dogToPoodleConverter(myDog);

        Console.WriteLine($"Converted dog name: {myPoodle.Name}");        
        Console.WriteLine();
    }

    public void Example2()
    {
        // Covariance: method returns more derived type (Poodle)
        Converter<Dog, Dog> dogToDogConverter = ConvertDogToPoodle;
        Dog myDog = new Dog() { Name = "Rex" };

        Dog myConvertedDog = dogToDogConverter(myDog);
        
        Console.WriteLine($"Converted dog name: {myConvertedDog.Name}");        
        Console.WriteLine();
    }

    public void Example3()
    {
        Converter<Dog, Poodle> dogToPoodleConverter = ConvertDogToPoodle;

        List<Dog> dogs = new List<Dog>() { new Dog { Name = "Truffles" }, new Dog { Name = "Fuzzball" } };        
        List<Poodle> poodles = dogs.Select(dog => dogToPoodleConverter(dog)).ToList();

        poodles[0].DoBackflip();
    }

    public void Covariance()
    {
        /** Covariance (return more derived types) */

        IEnumerable<string> strings = new List<string>();

        // An object that is instantiated with a more derived type argument
        // is assigned to an object instantiated with a less derived type argument.
        // Assignment compatibility is preserved.
        IEnumerable<object> objects = strings; // Covariance

        Console.WriteLine(objects);
        Console.WriteLine();
    }
    
    public void Contravariance()
    {
        /** Contravariance (accept parameters that have less derived types) */

        Action<object> actObject = obj => Console.WriteLine(obj);

        // An object that is instantiated with a less derived type argument
        // is assigned to an object instantiated with a more derived type argument.
        // Assignment compatibility is reversed.
        Action<string> actString = actObject; // Contravariance

        actString("Hello, Contravariance!");
        Console.WriteLine();
    }    

}