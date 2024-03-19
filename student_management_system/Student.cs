using System;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int RollNumber { get; }
    public string Grade { get; set; }

    private static int nextRollNumber = 1;

    public Student(string name, int age, string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
        RollNumber = nextRollNumber++;
    }
}