namespace Examples;

/**
 * You can declare generic type parameters in interfaces as covariant or contravariant. 
 * Covariance allows interface methods to have more derived return types than that defined by the generic type parameters. 
 * Contravariance allows interface methods to have argument types that are less derived than that specified by the generic parameters. 
 * A generic interface that has covariant or contravariant generic type parameters is called variant.
 * You can declare a generic type parameter covariant by using the out keyword.
 * 
 * The contravariant type can be used only as a type of method arguments and not as a return type of interface methods. 
 * The contravariant type can also be used for generic constraints. 
 * You can declare a generic type parameter contravariant by using the in keyword. 
 * 
 */

internal class CreatingVariantGenericInterfacesDemo
{
    public static void Run()
    {
        var examples = new CreatingVariantGenericInterfacesDemo();


    }

    public class ImplementVariantGeneric 
    {
        /** 
         * Declaring Variant Generic Interfaces 
         */
        interface ICovariant<out R>
        {
            R GetSomething();

            // The following statement generates a compiler error.
            // void SetSomething(R sampleArg);

            void DoSomething(Action<R> callback);

            // The following statement generates a compiler error
            // because you can use only contravariant or invariant types
            // in generic constraints.
            // void DoSomething<T>() where T : R;
        }
        interface IContravariant<in A>
        {
            void SetSomething(A sampleArg);
            void DoSomething<T>() where T : A;

            // The following statement generates a compiler error.
            // A GetSomething();
        }
        interface IVariant<out R, in A>
        {
            R GetSomething();
            void SetSomething(A sampleArg);
            R GetSetSomethings(A sampleArg);
        }


        /** 
         * Implementing Variant Generic Interfaces 
         */
        class SampleImplementation<R> : ICovariant<R>
        {
            public void DoSomething(Action<R> callback)
            {
                throw new NotImplementedException();
            }

            public R GetSomething()
            {
                // Some code.
                return default(R);
            }
        }

        class Button { }

        public void ExampleWithVariantGenericInterfaces()
        {
            // Covariant interface
            ICovariant<Apple> covariantApple = null;
            ICovariant<Fruit> covariantFruit = covariantApple; // Covariance: more derived to less derived

            // Contravariant interface
            IContravariant<Fruit> contravariantFruit = null;
            IContravariant<Apple> contravariantApple = contravariantFruit; // Contravariance: less derived to more derived


            /**
             * Classes that implement variant interfaces are invariant. For example, consider the following code.
             */

            // The interface is covariant.
            ICovariant<Button> ibutton = new SampleImplementation<Button>();
            ICovariant<Object> iobj = ibutton;

            // The class is invariant.
            SampleImplementation<Button> button = new SampleImplementation<Button>();

            // The following statement generates a compiler error because classes are invariant.
            // SampleImplementation<Object> obj = button;
        }

    }

    public class ExtendVariantGeneric
    {
        /**
         * Extending Variant Generic Interfaces
         */
        interface ICovariant<out T> { }
        interface IContravariant<in T> { }

        interface IInvariant<T> : ICovariant<T>, IContravariant<T> { }
        interface IExtCovariant<out T> : ICovariant<T> { }

        // The following statement generates a compiler error.
        // interface ICoContraVariant<in T> : ICovariant<T> { }
    }

    //public class AvoidingAmbiguity
    //{
    //    // Simple class hierarchy.
    //    class Animal { }
    //    class Cat : Animal { }
    //    class Dog : Animal { }

    //    // This class introduces ambiguity
    //    // because IEnumerable<out T> is covariant.
    //    class Pets : IEnumerable<Cat>, IEnumerable<Dog>
    //    {
    //        IEnumerator<Cat> IEnumerable<Cat>.GetEnumerator()
    //        {
    //            Console.WriteLine("Cat");
    //            // Some code.
    //            return null;
    //        }

    //        IEnumerator IEnumerable.GetEnumerator()
    //        {
    //            // Some code.
    //            return null;
    //        }

    //        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
    //        {
    //            Console.WriteLine("Dog");
    //            // Some code.
    //            return null;
    //        }
    //    }

    //    public void Test()
    //    {
    //        // In this example, it is unspecified how the pets.GetEnumerator method chooses between Cat and Dog. This could cause problems in your code.
    //        IEnumerable<Animal> pets = new Pets();
    //        pets.GetEnumerator();
    //    }
    //}
}

