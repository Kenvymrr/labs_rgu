using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("The flag is not entered");
            return;
        }

        string input;
        if (args[0] == "-c" && args.Length < 2)
        {
            Console.WriteLine("Enter a sequence of characters separated by spaces:");
            input = Console.ReadLine();
        }
        else if (args[0] == "-f" && args.Length > 1 && args.Length < 3)
        {
            string filePath = args[1];
            if (File.Exists(filePath))
            {
                input = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("The file was not found.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Incorrect input of the flag.");
            return;
        }

        double result = CalculateAverage(input);
        Console.WriteLine($"Arithmetic mean: {result}");
    }

    static double CalculateAverage(string input)
    {
        var charArray = input.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var numbers = charArray.Select(s =>
        {
            if (double.TryParse(s.Replace('.', ','), out double number))
            {
                return number;
            }
            else
            {
                return 0; // Non-numeric values are counted as 0
            }
        });

        return numbers.Any() ? numbers.Average() : 0;
    }
}
