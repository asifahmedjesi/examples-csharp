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

public class Weapon { }
public class Sword : Weapon { }
public class TwoHandedSword : Sword { }

internal class CovarianceContravarianceDemo3
{
    public static void Run()
    {
        var examples = new CovarianceContravarianceDemo3();
        
        var weapon = examples.Covariance();
        Console.WriteLine($"Covariance returned a weapon of type: {weapon.GetType().Name}");

        // var twoHandedSword = examples.BreakCovariance(); // ERROR: InvalidCastException at runtime
        // Console.WriteLine($"This line will not be reached due to invalid cast.");

        // We can pass a Sword as a Weapon
        examples.Contravariance(new Sword());

        // We cannot pass a Weapon as a Sword
        // examples.BreakContravariance(new Weapon()); // Compilation error 
    }

    /// Covariance means you can return (output) the instance of a subtype as its supertype. 
    /// Here is an example:

    // We can return a Sword into a Weapon
    private Weapon Covariance() => new Sword();

    // We cannot return a Sword into a TwoHandedSword
    private TwoHandedSword BreakCovariance() => (TwoHandedSword)new Sword();

    /// NOTE: 
    /// - As shown in the preceding example, one way to break covariance is to return a supertype as a subtype. 
    /// - This will result in an invalid cast exception at runtime.
    /// - Covariance is typically safe when used with immutable types or read-only collections,


    /// On the other hand, contravariance means you can input the instance of a subtype as its supertype. 
    /// It is basically the same thing but for inputs, like this:

    private void Contravariance(Weapon weapon) { }
    private void BreakContravariance(Sword weapon) { }

}