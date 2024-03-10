
using System;

class Program
{
    public static bool IsPalindrome(string str)
    {
        int i = 0, j = str.Length - 1;
        while (i < j)
        {
            if (str[i] != str[j])
            {
                return false;
            }
            else{
                i+=1;
                j-=1;
            }
        }
        return true; 
    }

    static void Main()
    {
        string str = "madkam";
        Console.WriteLine(IsPalindrome(str)); // True
    }
}