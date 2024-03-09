using System;
using System.Collections.Generic;

class Program
{
    public static Dictionary<char, int> CounterOfWord(string word){
        Dictionary<char, int> counter = new Dictionary<char, int>();
        foreach (var letter in word)
        {
            if (!char.IsLetter(letter)){
                continue;
            }
            else if (counter.ContainsKey(letter))
            {
                counter[letter]++;
            }
            else
            {
                counter.Add(letter, 1);
            }
        }

        return counter;
    }

     static void Main(){
        var counter = CounterOfWord("Hel',,,lo Worldhhh");
        foreach (var pair in counter)
        {
            Console.WriteLine($"Character: {pair.Key}, Count: {pair.Value}");
        }
}
}