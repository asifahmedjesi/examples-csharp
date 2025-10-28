namespace MyProduct
{
    namespace Component
    {
        class MyClass
        {
            public static int x;

            public static void Run()
            {
                Console.WriteLine("Running MyClass...");
            }
        }
    }
}

// More concise syntax for nested namespaces introduced in C# 10.0
namespace YourProduct.Component
{
    class MyClass 
    { 
        
    }
}

namespace OtherProduct
{
    class MyApp
    {
        public static void Run()
        {
            Console.WriteLine("Running MyApp...");
        }
    }
}