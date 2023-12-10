using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string inputString = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Select an action (a, b, c, d, e or q to exit):");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case 'a':
                    if (!IsStringNullOrEmpty(inputString))
                        SortAndPrintLastCharacters(inputString);
                    break;
                case 'b':
                    if (!IsStringNullOrEmpty(inputString))
                        ModifyString(inputString);
                    break;
                case 'c':
                    if (!IsStringNullOrEmpty(inputString))
                        CountOccurrences(inputString);
                    break;
                case 'd':
                    if (!IsStringNullOrEmpty(inputString))
                        inputString = ReplaceSecondLastWord(inputString);
                    break;
                case 'e':
                    if (!IsStringNullOrEmpty(inputString))
                        FindKthCapitalWord(inputString);
                    break;
                case 'q':
                    return;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
        }
    }

    static bool IsStringNullOrEmpty(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            Console.WriteLine("The string is empty or contains only spaces.");
            return true;
        }
        return false;
    }

    static void SortAndPrintLastCharacters(string input)
    {
        string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        string lastCharactersWord = string.Join("", words.Select(word => word.Last()));
        Console.WriteLine("A word from the last characters of the sorted words: " + lastCharactersWord);
    }

    static void ModifyString(string input)
    {
        string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string modifiedString = string.Join(" ", words.Select(word => char.ToUpper(word[0]) + word.Substring(1, word.Length - 2) + char.ToLower(word[word.Length - 1])));
        Console.WriteLine("Modified line: " + modifiedString);
    }

    static void CountOccurrences(string input)
    {  
        Console.WriteLine("Enter the word to count:");
        string wordToCount = Console.ReadLine();
        int count = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count(word => word == wordToCount);
        Console.WriteLine($"Word \"{wordToCount}\" occurs {count} times.");
    }


    static string ReplaceSecondLastWord(string input)
    {
        Console.WriteLine("Enter a new replacement word:");
        string newWord = Console.ReadLine();

        string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length >= 2)
        {
            words[words.Length - 2] = newWord;
            string replacedString = string.Join(" ", words);
            Console.WriteLine("The line after the replacement: " + replacedString);
            return replacedString;
        }
        else
        {
            Console.WriteLine("The string does not contain enough words to replace.");
            return input;
        }
    }

    static void FindKthCapitalWord(string input)
    {
        Console.WriteLine("Enter a value k:");
        if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0)
        {
            Console.WriteLine("Invalid value k.");
            return;
        }

        string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int capitalCount = 0;
        foreach (string word in words)
        {
            if (char.IsUpper(word[0]))
            {
                capitalCount++;
                if (capitalCount == k)
                {
                    Console.WriteLine($"The k-th word starting with a capital letter: {word}");
                    return;
                }
            }
        }

        Console.WriteLine("There is no single word starting with a capital letter in the line.");
    }
}
