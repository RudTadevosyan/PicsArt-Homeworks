using System;
namespace LongestWordSplit;

class Program
{
    static void LongestWord(string str)
    {
        char[] chars = {' ', ',', '!', '?', '.', ';', ':'};
        string[] words = str.Split(chars);

        string longestWord = "";
        foreach (string word in words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }

        Console.WriteLine($"Longest Word: {longestWord}");
    }
    static void Main(string[] args)
    {
        Console.Write("Input a sentence: ");
        string? str;

        do
        {
            str = Console.ReadLine();
        }while(string.IsNullOrEmpty(str));

        LongestWord(str);


    }
}