namespace Examples;

/**
 * 
 * Covariance
 * Covariance allows the use of a derived type in place of a base type. 
 * It is supported for reference type parameters in method returns, arrays, delegates, and generic interfaces.
 * 
 * 
 * Contravariance
 * Contravariance is the concept opposite to covariance. 
 * It allows the use of a base type in place of a derived type.
 * 
 * 
 * Invariance
 * If a type is neither covariant nor contravariant, it is said to be invariant. 
 * An invariant generic type maintains the exact identity of the type parameter. 
 * This means you cannot use a different type than the one specified as the parameter of the generic type.
 * 
 */

public class MyVariances
{
    public class Animal { }
    public class Dog : Animal { }
    public class Cat : Animal { }

    delegate void Action<in T>(T arg);

    public Animal GetAnimal()
    {
        return new Dog(); // This operation is allowed
    }
    public Dog GetDog()
    {
        // return new Animal(); // This operation is NOT allowed
        return new Dog(); // This operation is allowed
    }

    public void ProcessAnimals(List<Animal> animals)
    {

    }

    public void Example()
    {
        /** Covariance in action with IEnumerable */
        {
            IEnumerable<Dog> dogs = new List<Dog>();
            IEnumerable<Animal> animals = dogs; // This operation is allowed (Covariance allowed for IEnumerable)
        }
        {
            IEnumerable<Animal> animals = new List<Animal>();
            // dogs = animals; // This operation is NOT allowed
        }
        {
            IList<Dog> dogs = new List<Dog>();
            // IList<Animal> animals = dogs; // ERROR: Covariance not allowed for IList
        }

        /** Contravariance in action with Action delegate */
        {
            Action<Animal> animalAction = (Animal a) => Console.WriteLine(a);
            Action<Dog> dogAction = animalAction; // This operation is allowed
            dogAction(new Dog()); // Prints "Dog"
        }
        {
            Action<Dog> dogAction = (Dog d) => Console.WriteLine(d);
            // Action<Animal> animalAction = dogAction; // This operation is NOT allowed
        }

        /** Invariance in action with generic types */
        {
            List<Dog> dogs = new List<Dog>(); // This operation is allowed
            List<Animal> animals = new List<Animal>(); // This operation is allowed

            // List<Animal> animals = new List<Dog>(); // This operation is NOT allowed
            // List<Dog> dogs = new List<Animal>(); // This operation is NOT allowed

            // ProcessAnimals(dogs); // This operation is NOT allowed
        }

    }
}

/** Covariance in Generics */
public class Covariance
{
    public class Person { }
    public class Employee : Person { }

    public interface ICovariant<out T> { }
    public class ImplementICovariant<T> : ICovariant<T> { }

    public ICovariant<Person> icovPerson = new ImplementICovariant<Person>();
    public ICovariant<Employee> icovEmployee = new ImplementICovariant<Employee>();

    public void Example()
    {
        /** Covariance allows us to assign a derived type to a base type */

        icovPerson = icovEmployee; // This operation is allowed        
        // icovEmployee = icovPerson; // This operation is NOT allowed
    }
}

/** Contravariance in Generics */
public class Contravariance
{
    public class Person { }
    public class Employee : Person { }

    public interface IContravariant<in T> { }
    public class ImplementIContravariant<T> : IContravariant<T> { }

    public IContravariant<Person> icontraPerson = new ImplementIContravariant<Person>();
    public IContravariant<Employee> icontraEmployee = new ImplementIContravariant<Employee>();

    public void Example()
    {
        /** Contravariance allows us to assign a base type to a derived type */

        icontraEmployee = icontraPerson; // This operation is allowed        
        // icontraPerson = icontraEmployee; // This operation is NOT allowed
    }
}
