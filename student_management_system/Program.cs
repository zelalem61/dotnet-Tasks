using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var studentList = new StudentList<Student>();
        string jsonFilePath = "student.json";

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student by Name");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Save Student Data to JSON");
            Console.WriteLine("6. Load Student Data from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Student Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student Grade: ");
                    string grade = Console.ReadLine();
                    var newStudent = new Student(name, age, grade);
                    studentList.AddStudent(newStudent);
                    Console.WriteLine("Student added successfully.");
                    break;
                case "2":
                    Console.Write("Enter Student Name to search: ");
                    string searchName = Console.ReadLine();
                    var studentByName = studentList.GetStudentByName(searchName);
                    if (studentByName != null)
                    {
                        Console.WriteLine($"Name: {studentByName.Name}, Age: {studentByName.Age}, Roll Number: {studentByName.RollNumber}, Grade: {studentByName.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case "3":
                    Console.Write("Enter Student Roll Number to search: ");
                    int searchRollNumber = int.Parse(Console.ReadLine());
                    var studentById = studentList.GetStudentById(searchRollNumber);
                    if (studentById != null)
                    {
                        Console.WriteLine($"Name: {studentById.Name}, Age: {studentById.Age}, Roll Number: {studentById.RollNumber}, Grade: {studentById.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case "4":
                    var allStudents = studentList.GetAllStudents();
                    Console.WriteLine("All Students:");
                    foreach (var student in allStudents)
                    {
                        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
                    }
                    break;
                case "5":
                    studentList.SaveToJson(jsonFilePath);
                    break;
                case "6":
                    studentList.LoadFromJson(jsonFilePath);
                    break;
                case "7":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}