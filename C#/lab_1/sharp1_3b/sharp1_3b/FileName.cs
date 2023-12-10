using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        double[] numbers;
        if (args.Length < 1)
        {
            Console.WriteLine("The flag is not entered.");
            return;
        }
        else if (args[0] == "-c" && args.Length < 2)
        {
            Console.WriteLine("Enter a sequence of characters separated by spaces:");
            string input = Console.ReadLine();
            numbers = ReadNumbersFromInput(input);
        }
        else if (args[0] == "-f" && args.Length > 1 && args.Length < 3)
        {
            string filePath = args[1];
            try
            {
                numbers = ReadNumbersFromFile(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file was not found.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
                return;
            }
        }
        else
        {
            Console.WriteLine("Invalid command line arguments.");
            return;
        }

        
        // Вычисление среднего геометрического и среднего гармонического
        double geometricMean = CalculateGeometricMean(numbers);
        double harmonicMean = CalculateHarmonicMean(numbers);
        
        Console.WriteLine($"Geometric mean: {geometricMean}");
        Console.WriteLine($"The harmonic mean: {harmonicMean}");
        
    }

    static double[] ReadNumbersFromFile(string filePath)
    {
        try
        {
            string fileContent = File.ReadAllText(filePath);
            return ReadNumbersFromInput(fileContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
            return null;
        }
    }
    static double[] ReadNumbersFromInput(string input)
    {
        try
        {
            string[] numberStrings = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            double[] numbers = new double[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!double.TryParse(numberStrings[i].Replace('.', ','), out numbers[i]))
                {
                    numbers[i] = 0; // Replacing a non-numeric value with 0
                }
            }

            return numbers;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading numbers: {ex.Message}");
            return null;
        }
    }

    static double CalculateGeometricMean(double[] numbers)
    {
        double product = 1.0;

        foreach (double num in numbers)
        {
            product *= num;
        }

        return Math.Pow(product, 1.0 / numbers.Length);
    }

    static double CalculateHarmonicMean(double[] numbers)
    {
        double reciprocalSum = 0.0;

        foreach (double num in numbers)
        {
            reciprocalSum += 1.0 / num;
        }

        return numbers.Length / reciprocalSum;
    }
}
