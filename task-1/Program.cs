using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static double Average(List<int> scores)
    {
        return scores.Average();
    }

    static void Main(string[] args)
    {
        List<int> scores = new List<int>();
        List<string> subjects = new List<string>();

        bool isValidFullName = false;
        string name = "";

        while (!isValidFullName)
        {
            Console.WriteLine("Enter your full name  'example: Zelalem Hab': ");
            name = Console.ReadLine();
            if (name.Split(' ').Length != 2)
            {
                Console.WriteLine("Invalid input, please insert the correct input format");
                continue;
            }
            else
            {
                isValidFullName = true;
            }
        }

        bool isValidNoSubject = false;
        int no_of_subjects = 0;

        while (!isValidNoSubject)
        {
            Console.WriteLine("Enter the number of subjects you enrolled: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out no_of_subjects))
            {
                Console.WriteLine("invalid input, please insert a number");
            }
            else
            {
                isValidNoSubject = true;
            }
        }

        for (int i = 0; i < no_of_subjects; i++)
        {
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine($"Enter both the {i + 1}th subject and your score out of 100 'example: programming 84':");
                string grade = Console.ReadLine();
                string[] parts = grade.Split(' ');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input, please insert the correct input format");
                    continue;
                }
                else if (!int.TryParse(parts[1], out int score) || score < 0 || score > 100)
                {
                    Console.WriteLine("Invalid input, score should be a number between 0 and 100");
                    continue;
                }
                else
                {
                    scores.Add(score);
                    subjects.Add(parts[0]);
                    isValidInput = true;
                }
            }
        }

        double average = Average(scores);

        Console.WriteLine($"Hello {name}, your average score is {average}");
    }
}