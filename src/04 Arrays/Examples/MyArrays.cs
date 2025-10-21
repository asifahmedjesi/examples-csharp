using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyArrays
{
    public static void Run()
    {
        var examples = new MyArrays();

        examples.ArrayType();
        examples.OneDimensionalArray();
        examples.TwoDimensionalRectangularArray();
        examples.TwoDimensionalJaggedArray();        
    }

    public void ArrayType()
    {
        Console.WriteLine("## Array Types:");
        Console.WriteLine();

        int[] x = new int[3];
        Console.WriteLine($"{x.GetType().FullName} -> {x.GetType().BaseType?.FullName} -> {x.GetType().BaseType?.BaseType?.FullName}");
        
        string[,] y = new string[2, 2];
        Console.WriteLine($"{y.GetType().FullName} -> {y.GetType().BaseType?.FullName} -> {y.GetType().BaseType?.BaseType?.FullName}");
        
        string[][] z = new string[2][];
        Console.WriteLine($"{z.GetType().FullName} -> {z.GetType().BaseType?.FullName} -> {z.GetType().BaseType?.BaseType?.FullName}");
        
        Console.WriteLine();
    }

    public void OneDimensionalArray()
    {
        Console.WriteLine("## One Dimensional Arrays:");
        Console.WriteLine();

        /// one dimensional array
        int[] x1;           // integer array
        x1 = new int[3];    // allocate memory for 3 integers

        int[] x2 = new int[3];
        x2[0] = 1;
        x2[1] = 2;
        x2[2] = 3;

        int[] x3 = new[] { 1, 2, 4 };

        int[] y = new int[] { 1, 2, 3, 4 };
        int[] z = { 1, 2, 3, 4, 5 };

        Console.WriteLine($"{x1.GetType().FullName} {typeof(int[]).FullName}");
        Console.WriteLine($"x[0] + x[1] + x[2]: {x2[0] + x2[1] + x2[2]}");
        Console.WriteLine($"One Dimensional Array (x1): {string.Join(", ", x1)}");
        Console.WriteLine($"One Dimensional Array (x2): {string.Join(", ", x2)}");
        Console.WriteLine($"One Dimensional Array (y): {string.Join(", ", y)}");
        Console.WriteLine($"One Dimensional Array (z): {string.Join(", ", z)}");

        #region Array Creation Variations

        int[] a1 = new int[] { 1, 2, 3 };
        int[] a2 = new[] { 1, 2, 3 };
        int[] a3 = { 1, 2, 3 };
        int[] a4 = [1, 2, 3];

        var y1 = new int[] { 1, 2, 3 };
        var y2 = new[] { 1, 2, 3 };
        // var y3 = { 1, 2, 3 };    // ERROR: Implicitly-typed arrays must have an initializer
        // var y4 = [1, 2, 3];      // ERROR: Array creation must have array size or array initializer

        int[] z1 = new int[3];
        var z2 = new int[3];

        #endregion

        #region Array Initializers Variations

        int[] arr1 = { 1, 2, 3 };
        // var arr = { 1, 2, 3 };          // ERROR: Implicitly-typed arrays must have an initializer
        var arr2 = new[] { 1, 2, 3 };

        int[] arr3 = [1, 2, 3];
        // var arr = [1, 2, 3]      		// ERROR: Implicitly-typed arrays must have an initializer
        // var arr = new int[][1, 2, 3];    // ERROR: Array creation must have array size or array initializer

        #endregion

        Console.WriteLine();
    }

    public void TwoDimensionalRectangularArray()
    {
        Console.WriteLine("## Two Dimensional Rectangular Arrays:");
        Console.WriteLine();

        string[,] x = new string[2, 2];
        x[0, 0] = "00";
        x[0, 1] = "01";
        x[1, 0] = "10";
        x[1, 1] = "11";

        string[,] y = { { "x00", "x01" }, { "x10", "x11" } };

        Console.WriteLine($"{x.GetType().FullName} {typeof(string[,]).FullName}");
        Console.WriteLine($"Two Dimensional Rectangular Array (x):");
        for (int i = 0; i < x.GetLength(0); i++)
        {
            for (int j = 0; j < x.GetLength(1); j++)
            {
                Console.Write($"{x[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine($"Two Dimensional Rectangular Array (y):");
        for (int i = 0; i < y.GetLength(0); i++)
        {
            for (int j = 0; j < y.GetLength(1); j++)
            {
                Console.Write($"{y[i, j]} ");
            }
            Console.WriteLine();
        }

        var rectMatrix = new[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8}
        };

        Console.WriteLine();
    }

    public void TwoDimensionalJaggedArray()
    {
        Console.WriteLine("## Two Dimensional Jagged Arrays:");
        Console.WriteLine();

        string[][] a = new string[2][];
        a[0] = new string[1];
        a[0][0] = "00";
        a[1] = new string[2];
        a[1][0] = "10";
        a[1][1] = "11";

        string[][] b =  {
                    new string[] { "00" },
                    new string[] { "10", "11" }
                };

        string[][] c =  {
                    new[] { "00" },
                    new[] { "10", "11" }
                };

        var vowels1 = new char[] { 'a', 'e', 'i', 'o', 'u' };
        var vowels2 = new[] { 'a', 'e', 'i', 'o', 'u' };
        char[] vowels3 = { 'a', 'e', 'i', 'o', 'u' };
        char[] vowels4 = ['a', 'e', 'i', 'o', 'u'];
        
        var jaggedMatrix = new int[][]
        {
            new[] {0,1,2},
            new[] {3,4,5,6},
            new[] {7,8,9,10,11}
        };

        Console.WriteLine($"{a.GetType().FullName} {typeof(string[][]).FullName}");
        Console.WriteLine($"Two Dimensional Jagged Array (a):");
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a[i].Length; j++)
            {
                Console.Write($"{a[i][j]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

    }
}
