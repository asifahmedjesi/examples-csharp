namespace Examples;

public class MyPrimaryConstructor
{
    public static void Run()
    {
        Person p = new Person("Alice", "Jones");
        p.Print(); // Alice Jones

        var tom = new Employee(firstName: "Tom", lastName: "Cruise");
        var amir = new Employee(firstName: "Amir", lastName: "Khan", age: 56);

        var stew = new Student(firstName: "Stew", lastName: "Kumar");
    }
}

public class Person(string firstName, string lastName)
{
    public void Print() => Console.WriteLine(firstName + " " + lastName);
}

public class Person2(string firstName, string lastName)
{
    // Primary constructors and field/property initializers
    public readonly string FirstName = firstName;   // Field 
    public string LastName { get; } = lastName;     // Property

    public void Print() => Console.WriteLine(firstName + " " + lastName);
}

public class Person3(string firstName, string lastName)
{
    // Masking primary constructor parameters
    readonly string firstName = firstName;
    readonly string lastName = lastName;

    public void Print() => Console.WriteLine(firstName + " " + lastName);
}

public class Person4(string firstName, string lastName)
{
    // Validating primary constructor parameters
    readonly string lastName = (lastName == null) ? throw new ArgumentNullException("lastName") : lastName.ToUpper();

    // Property
    public string LastName { get; set; } = lastName;

    // Perform computation in field initializers 
    public readonly string FullName = firstName + " " + lastName;

    public void Print() => Console.WriteLine(FullName);
}

public class Employee(string firstName, string lastName)
{
    public Employee(string firstName, string lastName, int age) : this(firstName, lastName) // Must call the primary constructor
    {

    }
}

public class Student // (without primary constructors)
{
    string firstName, lastName; // Field declarations

    public Student(string firstName, string lastName) // Constructor
    {
        this.firstName = firstName; // Assign field 
        this.lastName = lastName;   // Assign field
    }

    public void Print() => Console.WriteLine(firstName + " " + lastName);
}