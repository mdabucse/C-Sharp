using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting async operations...\n");

        try
        {
            // Start all tasks 
            Task<string> task1 = GetDataFromSource1();
            Task<string> task2 = GetDataFromSource2();
            Task<string> task3 = GetDataFromSource3();

            // Wait for all tasks to complete
            string[] results = await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("\nAll tasks completed!\n");

            // Print results
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }

        Console.WriteLine("\nProgram finished.");
    }

    // Simulated async method 1
    static async Task<string> GetDataFromSource1()
    {
        Console.WriteLine("Fetching data from Source 1...");
        await Task.Delay(2000); // simulate delay
        return "Data from Source 1";
    }

    // Simulated async method 2
    static async Task<string> GetDataFromSource2()
    {
        Console.WriteLine("Fetching data from Source 2...");
        await Task.Delay(3000); // simulate delay
        return "Data from Source 2";
    }

    // Simulated async method 3 
    static async Task<string> GetDataFromSource3()
    {
        Console.WriteLine("Fetching data from Source 3...");
        await Task.Delay(1500);
        return "Data from Source 3";
    }
}