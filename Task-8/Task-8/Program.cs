using System;
using System.Collections.Generic;
using System.Linq;

#region Entity
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
#endregion

#region Interface
interface IRepository<T> where T : class
{
    void Add(T item);
    List<T> GetAll();
    void Update(int id, T item);
    void Delete(int id);
}
#endregion

#region Repository Implementation
class Repository<T> : IRepository<T> where T : class
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
        Console.WriteLine("✅ Item added successfully!");
    }

    public List<T> GetAll()
    {
        return items;
    }

    public void Update(int id, T newItem)
    {
        var oldItem = items.FirstOrDefault(x => GetId(x) == id);

        if (oldItem != null)
        {
            items.Remove(oldItem);
            items.Add(newItem);
            Console.WriteLine("✅ Item updated successfully!");
        }
        else
        {
            Console.WriteLine("❌ Item not found!");
        }
    }

    public void Delete(int id)
    {
        var item = items.FirstOrDefault(x => GetId(x) == id);

        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine("✅ Item deleted successfully!");
        }
        else
        {
            Console.WriteLine("❌ Item not found!");
        }
    }

    // Helper method to extract Id dynamically
    private int GetId(T item)
    {
        return (int)item.GetType().GetProperty("Id").GetValue(item);
    }
}
#endregion

#region Program (Console UI)
class Program
{
    static void Main()
    {
        Repository<Product> repo = new Repository<Product>();

        while (true)
        {
            Console.WriteLine("\n===== PRODUCT MANAGEMENT =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("❌ Invalid input!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddProduct(repo);
                    break;

                case 2:
                    ViewProducts(repo);
                    break;

                case 3:
                    UpdateProduct(repo);
                    break;

                case 4:
                    DeleteProduct(repo);
                    break;

                case 5:
                    Console.WriteLine("👋 Exiting...");
                    return;

                default:
                    Console.WriteLine("❌ Invalid choice!");
                    break;
            }
        }
    }

    static void AddProduct(Repository<Product> repo)
    {
        Product p = new Product();

        Console.Write("Enter Id: ");
        p.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        p.Name = Console.ReadLine();

        Console.Write("Enter Price: ");
        p.Price = double.Parse(Console.ReadLine());

        repo.Add(p);
    }

    static void ViewProducts(Repository<Product> repo)
    {
        var products = repo.GetAll();

        if (products.Count == 0)
        {
            Console.WriteLine(" No products found.");
            return;
        }

        Console.WriteLine("\n--- Product List ---");
        foreach (var p in products)
        {
            Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
        }
    }

    static void UpdateProduct(Repository<Product> repo)
    {
        Console.Write("Enter Id to update: ");
        int id = int.Parse(Console.ReadLine());

        Product p = new Product();
        p.Id = id;

        Console.Write("Enter New Name: ");
        p.Name = Console.ReadLine();

        Console.Write("Enter New Price: ");
        p.Price = double.Parse(Console.ReadLine());

        repo.Update(id, p);
    }

    static void DeleteProduct(Repository<Product> repo)
    {
        Console.Write("Enter Id to delete: ");
        int id = int.Parse(Console.ReadLine());

        repo.Delete(id);
    }
}
#endregion