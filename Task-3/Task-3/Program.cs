using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> items = new List<string>();
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Display Items");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine().Trim();
            if (choice == "1")
            {
                Console.Write("Enter item: ");
                string item = Console.ReadLine().Trim();

                item = item.ToUpper(); // convert to uppercase

                items.Add(item);

                Console.WriteLine("Item added!");
            }
            else if (choice == "2")
            {
                Console.Write("Enter item to remove: ");
                string item = Console.ReadLine().Trim().ToUpper();

                if (items.Remove(item))
                {
                    Console.WriteLine("Item removed!");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("\n--- Items ---");

                if (items.Count == 0)
                {
                    Console.WriteLine("No items available.");
                }
                else
                {
                    foreach (string item in items)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }

        }
    }
}