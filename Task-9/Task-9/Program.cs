using System;
using System.Linq;
using System.Reflection;

// Custom Attribute
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
}

// Sample Classes
public class TaskOne
{
    [Runnable]
    public void Run()
    {
        Console.WriteLine("TaskOne is running...");
    }
}

public class TaskTwo
{
    [Runnable]
    public void Execute()
    {
        Console.WriteLine("TaskTwo is executing...");
    }
}

public class TaskThree
{
    public void NotRunnable()
    {
        Console.WriteLine("This should NOT run");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Discovering Runnable methods...\n");

        // Get current assembly
        var assembly = Assembly.GetExecutingAssembly();

        // Get all types 
        var types = assembly.GetTypes();

        foreach (var type in types)
        {
            // Get all methods of each class
            var methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                // Check if method has [Runnable]
                var hasAttribute = method.GetCustomAttributes(typeof(RunnableAttribute), false).Any();

                if (hasAttribute)
                {
                    Console.WriteLine($"Executing: {type.Name}.{method.Name}");

                    // Create instance of class
                    var instance = Activator.CreateInstance(type);

                    // Invoke method
                    method.Invoke(instance, null);
                }
            }
        }

        Console.WriteLine("\nExecution Completed!");
    }
}