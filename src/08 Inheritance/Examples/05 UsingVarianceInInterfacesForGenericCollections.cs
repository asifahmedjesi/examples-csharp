using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

/**
 * A covariant interface allows its methods to return more derived types than those specified in the interface. 
 * A contravariant interface allows its methods to accept parameters of less derived types than those specified in the interface.
 * 
 * NOTE:
 * For covariant, I'm providing more derived type (Employee) where less derived type (Person) is expected.
 * For contravariant, I'm providing less derived type (PersonComparer) where more derived type (Employee) is expected.
 * 
 */

// Simple hierarchy of classes.  
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Employee : Person { }

// The custom comparer for the Person type with standard implementations of Equals() and GetHashCode() methods.
internal class PersonComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        if (Object.ReferenceEquals(x, y)) return true;
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

        return x.FirstName == y.FirstName && x.LastName == y.LastName;
    }

    public int GetHashCode(Person person)
    {
        if (Object.ReferenceEquals(person, null)) return 0;
        int hashFirstName = person.FirstName == null ? 0 : person.FirstName.GetHashCode();
        int hashLastName = person.LastName.GetHashCode();

        return hashFirstName ^ hashLastName;
    }
}


internal class UsingVarianceInInterfacesForGenericCollections
{
    /**
     * Converting Generic Collections
     */
    public void ExampleConvertingGenericCollections()
    {
        IEnumerable<Employee> employees = new List<Employee>();

        // You can pass IEnumerable<Employee>, although the method expects IEnumerable<Person>.  
        PrintFullName(employees);

    }

    // The method has a parameter of the IEnumerable<Person> type.  
    public void PrintFullName(IEnumerable<Person> persons)
    {
        foreach (Person person in persons)
        {
            Console.WriteLine("Name: {0} {1}", person.FirstName, person.LastName);
        }
    }


    /**
     * Comparing Generic Collections
     */
    public void ExampleComparingGenericCollections()
    {
        List<Employee> employees = new List<Employee> {
               new Employee() { FirstName = "Michael", LastName = "Alexander" },
               new Employee() { FirstName = "Jeff", LastName = "Price" }
            };

        // You can pass PersonComparer, which implements IEqualityComparer<Person>, although the method expects IEqualityComparer<Employee>
        IEnumerable<Employee> noduplicates = employees.Distinct<Employee>(new PersonComparer());

        foreach (var employee in noduplicates)
            Console.WriteLine(employee.FirstName + " " + employee.LastName);
    }
}
