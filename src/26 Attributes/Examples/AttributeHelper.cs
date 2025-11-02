using System.Reflection;

namespace Examples;

public class AttributeHelper
{
    public static void PrintOnConsole(Attribute attribute)
    {
        if (attribute is null)
        {
            Console.WriteLine("Attribute is null.");
            return;
        }

        Console.WriteLine($"Attribute Name: {attribute.GetType().FullName}");

        var properties = attribute.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        foreach (var property in properties)
        {
            var value = property.GetValue(attribute);
            Console.WriteLine($"{property.Name}: {value}");
        }
    }

    public static void PrintAttribute<T>(Type type, string methodName) where T : Attribute
    {
        var method = type.GetMethod(methodName);
        if (method is null)
        {
            Console.WriteLine($"Method {methodName} not found in type {type.Name}");
            return;
        }
        var attribute = type.GetCustomAttribute<T>(false);
        if (attribute is null)
        {
            Console.WriteLine($"Attribute {typeof(T).Name} not found on method {methodName} in type {type.Name}");
            return;
        }

        PrintOnConsole(attribute);


        //if (attribute is not TaskDescriptorAttribute)
        //{
        //    Console.WriteLine($"Attribute {typeof(T).Name} is not a TaskDescriptorAttribute.");
        //    return;
        //}

        //var taskDescriptor = attribute as TaskDescriptorAttribute;
        //if (taskDescriptor is null)
        //{
        //    Console.WriteLine($"Attribute {typeof(T).Name} is not a TaskDescriptorAttribute.");
        //    return;
        //}

        //Console.WriteLine($"Name: {taskDescriptor.Name}");
        //Console.WriteLine($"Description: {taskDescriptor.Description}");        
        //Console.WriteLine($"Needs Manager: {taskDescriptor.NeedsManager}");
        //Console.WriteLine($"Developer Count: {taskDescriptor.DeveloperCount}");
    }

    public static List<string> GetAttributesOfMethods(Type elementType)
    {
        List<string> attributes = new List<string>();

        var methodInfoList = elementType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        if (methodInfoList is null || methodInfoList.Length == 0)
        {
            Console.WriteLine($"The type {elementType} does not have any methods.");
            return attributes;
        }

        foreach (var methodInfo in methodInfoList)
        {
            var attributeList = Attribute.GetCustomAttributes(methodInfo, true);
            if (attributeList.Length == 0)
            {
                Console.WriteLine($"The {elementType.Name}.{methodInfo.Name} method does not have attributes.");
                continue;
            }

            Console.WriteLine($"The {elementType.Name}.{methodInfo.Name} method's attribute:");

            foreach (var att in attributeList)
            {
                PrintOnConsole(att);
                attributes.Add(methodInfo.Name + "-" + att.ToString());
            }

            Console.WriteLine();
        }

        return attributes;
    }
}
