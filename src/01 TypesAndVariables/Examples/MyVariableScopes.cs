using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

internal class MyVariableScopes
{
    public static void Run()
    {
        Console.WriteLine("VARIABLE SCOPES");
        Console.WriteLine();

        /// Local scope
        void LocalScopeExample()
        {
            int localVariable = 10;
            Console.WriteLine($"Local variable: {localVariable}");
        }
        LocalScopeExample();
        // Console.WriteLine(localVariable); // Error: localVariable is not accessible here

        /// Block scope
        {
            int blockVariable = 20;
            Console.WriteLine($"Block variable: {blockVariable}");
        }
        // Console.WriteLine(blockVariable); // Error: blockVariable is not accessible here

        /// Method scope
        int methodVariable = 30;
        Console.WriteLine($"Method variable: {methodVariable}");
        Console.WriteLine();

        /// Variable shadowing
        var local = "local scoped";

        {
            var scoped = "block scoped";
            Console.WriteLine(scoped + " 1");
            Console.WriteLine(local + " 1");

            // var local = "local scoped again"; // This will cause a compile-time error because 'local' is already defined in the outer scope
        }

        Console.WriteLine(local + " 2");

        // Console.WriteLine(scoped + " 2");    // This will cause a compile-time error because 'scoped' is not defined in this scope
        // The name 'scoped' does not exist in the current context
    }
}
