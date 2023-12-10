using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a decimal number: ");
        double decimalNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter the base of the number system (from 2 to 36): ");
        int baseNumber = int.Parse(Console.ReadLine());

        if (baseNumber < 2 || baseNumber > 36)
        {
            Console.WriteLine("The base of the number system should be in the range from 2 to 36.");
            return;
        }

        Console.WriteLine($"The result of the transfer: {ConvertDecimalToBase(decimalNumber, baseNumber)}");
        Console.ReadKey();
    }

    static string ConvertDecimalToBase(double decimalNumber, int baseNumber)
    {
        int integerPart = (int)decimalNumber;
        double fractionalPart = decimalNumber - integerPart;

        string integerPartInBase = ConvertIntegerToBase(integerPart, baseNumber);
        string fractionalPartInBase = ConvertFractionalPartToBase(fractionalPart, baseNumber);

        return $"{integerPartInBase}.{fractionalPartInBase}";
    }

    static string ConvertIntegerToBase(int integerPart, int baseNumber)
    {
        string result = "";

        while (integerPart > 0)
        {
            int remainder = integerPart % baseNumber;
            result = ConvertDigitToChar(remainder) + result;
            integerPart /= baseNumber;
        }

        return result.Length > 0 ? result : "0";
    }

    static string ConvertFractionalPartToBase(double fractionalPart, int baseNumber)
    {
        const int maxFractionalPartLength = 15;
        string result = "";
        int count = 0;

        while (fractionalPart > 0 && count < maxFractionalPartLength)
        {
            fractionalPart *= baseNumber;
            int digit = (int)fractionalPart;
            result += ConvertDigitToChar(digit);
            fractionalPart -= digit;

            count++;
        }

        return result.Length > 0 ? result : "0";
    }

    static char ConvertDigitToChar(int digit)
    {
        if (digit < 10)
        {
            return (char)('0' + digit);
        }
        else
        {
            return (char)('A' + digit - 10);
        }
    }
}
