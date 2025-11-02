namespace Examples;

/**
 * 
 * Covariance and contravariance are terms that refer to the ability to use a more derived type (more specific) or a less derived type (less specific) than originally specified. 
 * Generic type parameters support covariance and contravariance to provide greater flexibility in assigning and using generic types.
 * 
 * When you're referring to a type system, covariance, contravariance, and invariance have the following definitions. 
 * The examples assume a base class named Base and a derived class named Derived.
 * 
 * Covariance
 *      Enables you to use a more derived type than originally specified.
 *      You can assign an instance of IEnumerable<Derived> to a variable of type IEnumerable<Base>.
 *      
 * Contravariance
 *      Enables you to use a more generic (less derived) type than originally specified.
 *      You can assign an instance of Action<Base> to a variable of type Action<Derived>.
 *      
 * Invariance
 *      Means that you can use only the type originally specified. An invariant generic type parameter is neither covariant nor contravariant.
 *      You cannot assign an instance of List<Base> to a variable of type List<Derived> or vice versa.
 * 
 * 
 * In general, 
 * - a covariant type parameter can be used as the return type of a delegate, and 
 * - contravariant type parameters can be used as parameter types. 
 * 
 * For an interface, 
 * - covariant type parameters can be used as the return types of the interface's methods, and 
 * - contravariant type parameters can be used as the parameter types of the interface's methods.
 * 
 * Covariance and contravariance are collectively referred to as variance. 
 * A generic type parameter that is not marked covariant or contravariant is referred to as invariant. 
 * 
 * 
 * A brief summary of facts about variance in the common language runtime:
 * - Variant type parameters are restricted to generic interface and generic delegate types.
 * - A generic interface or generic delegate type can have both covariant and contravariant type parameters.
 * - Variance applies only to reference types; if you specify a value type for a variant type parameter, that type parameter is invariant for the resulting constructed type.
 * - Variance does not apply to delegate combination. 
 *      a. That is, given two delegates of types Action<Derived> and Action<Base>, you cannot combine the second delegate with the first although the result would be type safe. 
 *      b. Variance allows the second delegate to be assigned to a variable of type Action<Derived>, but delegates can combine only if their types match exactly.
 * - Starting in C# 9, covariant return types are supported. 
 *      a. An overriding method can declare a more derived return type the method it overrides, and an overriding, read-only property can declare a more derived type.
 * 
 * 
 * Generic interfaces with covariant type parameters:
 * - Several generic interfaces have covariant type parameters, for example, 
 *      IEnumerable<T>, 
 *      IEnumerator<T>, 
 *      IQueryable<T>, and 
 *      IGrouping<TKey,TElement>. 
 * - All the type parameters of these interfaces are covariant, so the type parameters are used only for the return types of the members.
 * 
 * 
 * Generic interfaces with contravariant type parameters:
 * - Several generic interfaces have contravariant type parameters; for example: 
 *      IComparer<T>, 
 *      IComparable<T>, and 
 *      IEqualityComparer<T>. 
 * - These interfaces have only contravariant type parameters, so the type parameters are used only as parameter types in the members of the interfaces.
 * 
 * 
 * Define variant generic interfaces and delegates:
 * - C# have keywords that enable you to mark the generic type parameters of interfaces and delegates as covariant or contravariant.
 * 
 * - A covariant type parameter is marked with the out keyword (Out keyword in Visual Basic). 
 * - You can use a covariant type parameter as the return value of a method that belongs to an interface, or as the return type of a delegate. 
 * - You cannot use a covariant type parameter as a generic type constraint for interface methods.
 * 
 * - A contravariant type parameter is marked with the in keyword (In keyword in Visual Basic). 
 * - You can use a contravariant type parameter as the type of a parameter of a method that belongs to an interface, or as the type of a parameter of a delegate. 
 * - You can use a contravariant type parameter as a generic type constraint for an interface method.
 * 
 * - Only interface types and delegate types can have variant type parameters. 
 * - An interface or delegate type can have both covariant and contravariant type parameters.
 * 
 * - C# do not allow you to violate the rules for using covariant and contravariant type parameters, or 
 * to add covariance and contravariance annotations to the type parameters of types other than interfaces and delegates.
 * 
 * 
 */

internal class CovarianceAndContravarianceInGenericsDemo
{
    public static void Run()
    {
        var examples = new CovarianceAndContravarianceInGenericsDemo();

        examples.ExamplesWithGenerics();
        examples.ExampleWithGenericInterfacesCovariant();
        examples.ExampleWithGenericInterfacesContravariant(); 
    }

    /**
     * Covariance and contravariance in generics
     */
    public void ExamplesWithGenerics()
    {
        // Covariance example
        // Covariant type parameters enable you to make assignments that look much like ordinary Polymorphism, as shown in the following code.
        IEnumerable<DerivedType> derivedCollection = new List<DerivedType>();
        IEnumerable<BaseType> baseCollection = derivedCollection; // This is allowed due to covariance (more derived to less derived)


        // Contravariance example
        // Contravariance, on the other hand, seems counterintuitive.
        // The following example creates a delegate of type Action<Base>, and then assigns that delegate to a variable of type Action<Derived>.
        Action<BaseType> baseAction = (target) => { Console.WriteLine(target.GetType().Name); };
        Action<DerivedType> derivedAction = baseAction; // This is allowed due to contravariance (less derived to more derived)
        derivedAction(new DerivedType());
    }

    /**
     * Generic interfaces with covariant type parameters
     */
    public void ExampleWithGenericInterfacesCovariant()
    {
        List<DerivedClass> dlist = new List<DerivedClass>();
        DerivedClass.PrintDerivedItems(dlist);
    }

    /**
     * Generic interfaces with contravariant type parameters
     */
    public void ExampleWithGenericInterfacesContravariant()
    {
        // You can pass ShapeAreaComparer, which implements IComparer<Shape>,
        // even though the constructor for SortedSet<Circle> expects IComparer<Circle>,
        // because type parameter T of IComparer<T> is contravariant.
        SortedSet<Circle> circlesByArea = new SortedSet<Circle>(new ShapeAreaComparer())
                {
                    new Circle(7.2),
                    new Circle(100),
                    null,
                    new Circle(.01)
                };

        foreach (Circle c in circlesByArea)
        {
            Console.WriteLine(c == null ? "null" : "Circle with area " + c.Area);
        }
    }

    /**
     * Generic delegates with variant type parameters
     */
    public DerivedClass MyMethod(BaseClass b)
    {
        return b as DerivedClass ?? new DerivedClass();
    }

    public void ExampleWithGenericDelegateVariance()
    {
        // Func<in T, out TResult> d;
        Func<BaseClass, DerivedClass> f1 = MyMethod;

        // Covariant return type.
        Func<BaseClass, BaseClass> f2 = f1;
        BaseClass b2 = f2(new BaseClass());

        // Contravariant parameter type.
        Func<DerivedClass, DerivedClass> f3 = f1;
        DerivedClass d3 = f3(new DerivedClass());

        // Covariant return type and contravariant parameter type.
        Func<DerivedClass, BaseClass> f4 = f1;
        BaseClass b4 = f4(new DerivedClass());
    }

    /**
     * Variance in non-generic delegates
     */
    public Type3 MyMethod(Type1 t)
    {
        return t as Type3 ?? new Type3();
    }

    public void ExampleWithNonGenericDelegateVariance()
    {
        Func<Type2, Type2> f1 = MyMethod;

        // Covariant return type and contravariant parameter type.
        Func<Type3, Type1> f2 = f1;
        Type1 t1 = f2(new Type3());
    }
}

#region Helper Classes for Generics Variance Examples

internal class BaseClass
{
    public static void PrintBases(IEnumerable<BaseClass> bases)
    {
        foreach (BaseClass b in bases)
        {
            Console.WriteLine(b);
        }
    }
}

internal class DerivedClass : BaseClass
{
    public static void PrintDerivedItems(IEnumerable<DerivedClass> derivedItems)
    {
        DerivedClass.PrintBases(derivedItems); // The covariant type parameter is the reason why an instance of IEnumerable<Derived> can be used instead of IEnumerable<Base>.
        IEnumerable<BaseClass> bIEnum = derivedItems;
    }
}


internal abstract class Shape
{
    public virtual double Area { get { return 0; } }
}

internal class Circle : Shape
{
    private double r;
    public Circle(double radius) { r = radius; }
    public double Radius { get { return r; } }
    public override double Area { get { return Math.PI * r * r; } }
}

internal class ShapeAreaComparer : System.Collections.Generic.IComparer<Shape>
{
    int IComparer<Shape>.Compare(Shape a, Shape b)
    {
        if (a == null) return b == null ? 0 : -1;
        return b == null ? 1 : a.Area.CompareTo(b.Area);
    }
}

public class Type1 { }
public class Type2 : Type1 { }
public class Type3 : Type2 { }

#endregion