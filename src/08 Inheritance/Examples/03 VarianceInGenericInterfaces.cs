using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

/**
 * Starting with .NET Framework 4, the following interfaces are variant:
 *      IEnumerable<T> (T is covariant)
 *      IEnumerator<T> (T is covariant)
 *      IQueryable<T> (T is covariant)
 *      IGrouping<TKey,TElement> (TKey and TElement are covariant)
 *      IComparer<T> (T is contravariant)
 *      IEqualityComparer<T> (T is contravariant)
 *      IComparable<T> (T is contravariant)
 *      
 * Starting with .NET Framework 4.5, the following interfaces are variant:
 *      IReadOnlyList<T> (T is covariant)
 *      IReadOnlyCollection<T> (T is covariant)
 */

// Comparer class.
internal class BaseComparer : IEqualityComparer<BaseClass>
{
    public int GetHashCode(BaseClass baseInstance)
    {
        return baseInstance.GetHashCode();
    }
    public bool Equals(BaseClass x, BaseClass y)
    {
        return x == y;
    }
}

internal class VarianceInGenericInterfaces
{
    public void Example()
    {
        // Covariance permits a method to have a more derived return type than that defined by the generic type parameter of the interface.
        // In earlier versions of .NET Framework, this code causes a compilation error in C#
        // Covariance example:
        IEnumerable<String> strings = new List<String>();
        IEnumerable<Object> objects = strings;


        // Contravariance permits a method to have argument types that are less derived than that specified by the generic parameter of the interface.
        // Contravariance example:
        IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

        // Implicit conversion of IEqualityComparer<BaseClass> to IEqualityComparer<DerivedClass>.
        IEqualityComparer<DerivedClass> childComparer = baseComparer;

        IComparer<object> objectComparer = Comparer<object>.Default;
        IComparer<string> stringComparer = objectComparer; // This is allowed due to contravariance
        int result = stringComparer.Compare("apple", "banana");
        Console.WriteLine(result);


        // Variance in generic interfaces is supported for reference types only.
        // Value types do not support variance.
        // For example, IEnumerable<int> cannot be implicitly converted to IEnumerable<object>, because integers are represented by a value type.
        IEnumerable<int> integers = new List<int>();
        // The following statement generates a compiler error because int is a value type.
        // IEnumerable<Object> objects = integers;


        // It is also important to remember that classes that implement variant interfaces are still invariant.
        // For example, although List<T> implements the covariant interface IEnumerable<T>,
        // you cannot implicitly convert List<String> to List<Object>. 
        List<String> stringList = new List<String>();
        // List<Object> list = stringList;

        // The following line generates a compiler error because classes are invariant.
        // List<Object> list = new List<String>();

        // You can use the interface object instead.
        IEnumerable<Object> listObjects = new List<String>();
    }
}
