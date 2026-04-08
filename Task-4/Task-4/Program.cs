using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20, Grade = 85 },
            new Student { Name = "Bob", Age = 22, Grade = 72 },
            new Student { Name = "Charlie", Age = 19, Grade = 90 },
            new Student { Name = "David", Age = 21, Grade = 60 },
            new Student { Name = "Eva", Age = 20, Grade = 88 }
        };

        Console.Write("Enter minimum grade: ");
        double threshold = Convert.ToDouble(Console.ReadLine());

        var sortedStudents = students
            .Where(s => s.Grade > threshold)
            .OrderBy(s => s.Name);

        Console.WriteLine("\nFiltered & Sorted Students:");

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
    }
}