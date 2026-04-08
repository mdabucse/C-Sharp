using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "D:\\Presidio Self Learning\\C#\\Task-5\\Task-5\\input.txt";
        string outputPath = "D:\\Presidio Self Learning\\C#\\Task-5\\Task-5\\output.txt";

        try
        {
            // Read file
            string content = File.ReadAllText(inputPath);

            // Process data
            int lineCount = content.Split('\n').Length;
            int wordCount = content.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // Prepare result
            string result = $"Lines: {lineCount}\nWords: {wordCount}";

            // Write to output file
            File.WriteAllText(outputPath, result);

            Console.WriteLine("Processing completed successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Input file not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}