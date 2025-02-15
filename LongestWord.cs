using System;
namespace LongestWord;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input a string: ");
        string? sentence = Console.ReadLine();
        
        if(!string.IsNullOrEmpty(sentence))
        {
            sentence += " ";
            string currentWord = "";
            string longestWord = "";
            int wordLength = 0;
            int maxLength = 0; 
            
            for(int i = 0; i < sentence.Length; i++)
            {
                if(sentence[i] == ' ' || sentence[i] == ',' || sentence[i] == '!' || sentence[i] == '?' || sentence[i] == '.')
                {
                    if(wordLength > maxLength)
                    {
                        maxLength = wordLength;
                        longestWord = currentWord;
                    }
                    
                    wordLength = 0;
                    currentWord = "";
                }
                else
                {
                    currentWord += sentence[i];
                    wordLength++;
                }
            }

            Console.WriteLine($"Longest word: {longestWord}");
        }
        else
        {
        Console.WriteLine("Input cannot be empty!");
        }
    }
}
