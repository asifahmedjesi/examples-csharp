using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class UsingVarianceForFuncAndActionGenericDelegates
{
    public class Animal
    {
        public string Name { get; set; }
    }
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }
    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("Meow!");
        }
    }

    // Simple hierarchy of classes.  
    public class Person 
    {
        public virtual void ReadContact() { /*...*/ }
    }
    public class Employee : Person 
    {
        public override void ReadContact() { /*...*/ }
    }

    public Employee FindByTitle(String title)
    {
        // This is a stub for a method that returns an employee that has the specified title.  
        return new Employee();
    }

    public void AddToContacts(Person person)
    {
        // This method adds a Person object to a contact list.  
    }

    /**
     * Using Delegates with Covariant Type Parameters
     */
    public void UsingDelegatesWithCovariantTypeParameters()
    {
        // Create an instance of the delegate without using variance.  
        Func<String, Employee> findEmployee = FindByTitle;

        // The delegate expects a method to return Person, but you can assign it a method that returns Employee.  
        Func<String, Person> findPerson = FindByTitle;

        // You can also assign a delegate that returns a more derived type to a delegate that returns a less derived type.
        findPerson = findEmployee;
    }

    /**
     * Using Delegates with Contravariant Type Parameters
     */
    public void UsingDelegatesWithContravariantTypeParameters()
    {
        // Create an instance of the delegate without using variance.  
        Action<Person> addPersonToContacts = AddToContacts;

        // The Action delegate expects
        // a method that has an Employee parameter,  
        // but you can assign it a method that has a Person parameter  
        // because Employee derives from Person.  
        Action<Employee> addEmployeeToContacts = AddToContacts;

        // You can also assign a delegate
        // that accepts a less derived parameter to a delegate
        // that accepts a more derived parameter.  
        addEmployeeToContacts = addPersonToContacts;
    }


    /**
     * Contravariance and anonymous functions 
     */
    public void ContravarianceAndAnonymousFunctions()
    {
        var personReadContact = (Person p) => p.ReadContact();

        // This works - contravariance allows assignment.
        Action<Employee> employeeReadContact = personReadContact;

        // This causes a compile error: CS1661.
        // Action<Employee> employeeReadContact2 = (Person p) => p.ReadContact();

        /**
         * 
         * This behavior seems contradictory: 
         * - if contravariance allows assigning a delegate that accepts a base type (Person) to a delegate variable expecting a derived type (Employee), 
         * - why does direct assignment of the lambda expression fail?
         * 
         * The key difference is type inference. 
         * In the first case, the lambda expression is first assigned to a variable with type var, which causes the compiler to infer the lambda's type as Action<Person>. 
         * The subsequent assignment to Action<Employee> succeeds because of contravariance rules for delegates.
         * 
         * In the second case, the compiler cannot directly infer that the lambda expression (Person p) => p.ReadContact() should have type Action<Person> when it's being assigned to Action<Employee>. 
         * The type inference rules for anonymous functions don't automatically apply contravariance during the initial type determination.
         * 
         */

        /**
         * Workarounds
         */
        // Explicit cast to the desired delegate type.
        Action<Employee> employeeReadContact2 = (Action<Person>)((Person p) => p.ReadContact());

        // Or specify the lambda parameter type that matches the target delegate.
        Action<Employee> employeeReadContact3 = (Employee e) => e.ReadContact();

        /**
         * This behavior illustrates the difference between 
         *      - delegate contravariance (which works after types are established) and 
         *      - lambda expression type inference (which occurs during compilation).
         */
    }

    public class Program
    {
        

        public static void Main()
        {
            // Covariance with Func<T>
            Func<Dog> getDog = () => new Dog { Name = "Buddy" };
            Func<Animal> getAnimal = getDog; // Covariant assignment
            Animal myAnimal = getAnimal();
            Console.WriteLine($"Animal Name: {myAnimal.Name}");
            // Contravariance with Action<T>
            Action<Animal> printAnimalName = (animal) => Console.WriteLine($"Animal Name: {animal.Name}");
            Action<Dog> printDogName = printAnimalName; // Contravariant assignment
            Dog myDog = new Dog { Name = "Max" };
            printDogName(myDog);
        }
    }
}
