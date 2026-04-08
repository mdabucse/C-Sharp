using System;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Introduce()
    {
        Console.WriteLine("Hello, my name is " + Name + " and I am " + Age + " years old.");
    }
}

class Program
{
    static void Main()
    {
        // Object 1
        Person p1 = new Person();
        p1.Name = "Abu";
        p1.Age = 21;

        // Object 2
        Person p2 = new Person();
        p2.Name = "Rahul";
        p2.Age = 25;

        // Call method
        p1.Introduce();
        p2.Introduce();
    }
}