using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class StudentList<T> where T : Student
{
    private List<T> students;

    public StudentList()
    {
        students = new List<T>();
    }

    public void AddStudent(T student)
    {
        students.Add(student);
    }

    public T GetStudentByName(string name)
    {
        return students.FirstOrDefault(s => s.Name == name);
    }

    public T GetStudentById(int rollNumber)
    {
        return students.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public List<T> GetAllStudents()
    {
        return students;
    }

    public void SaveToJson(string filePath)
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
        Console.WriteLine("Data saved to JSON file.");
    }

    public void LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<T>>(json);
            Console.WriteLine("Data loaded from JSON file.");
        }
        else
        {
            Console.WriteLine("JSON file not found.");
        }
    }
}