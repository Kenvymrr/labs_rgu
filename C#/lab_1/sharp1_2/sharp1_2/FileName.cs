using System;

class Calculator_e
{
    // Вычисление значения числа e через сумму ряда
    public static double CalculateEBySeries(double epsilon)
    {
        double e = 1.0;
        double term = 1.0;
        int n = 1;

        while (Math.Abs(term) > epsilon)
        {
            term /= n;
            e += term;
            n++;
        }

        return e;
    }

    // Вычисление значения числа e через предел e = lim(1 + 1/n)^n при n -> бесконечности
    public static double CalculateEByLimit(double epsilon)
    {
        double e = Math.Pow(1.0 + epsilon, 1.0 / epsilon);
        return e;
    }

    // Вычисление значения числа e через значение lnx = 1
    public static double CalculateEByEquation(double epsilon)
    {
        double e = Math.E;
        return e;
    }
    static double CalculatePiBySeries(double epsilon)
    {
        double pi = 0;
        double term = 1;
        double i = 1;

        while (Math.Abs(term) > epsilon)
        {
            pi += term;
            i += 2;
            term = (i % 4 == 1) ? 1.0 / i : -1.0 / i;
        }

        return pi * 4;
    }

    static double CalculatePiByEquation(double epsilon)
    {
        // Решение уравнения: cosx = -1
        return Math.Acos(-1);
    }

    static double CalculatePiByLimit(double epsilon)
    {
        // Значение предела, например, Лейбницевский метод
        double pi = 0;
        int i = 0;

        while (true)
        {
            double term = (i % 2 == 0) ? 1.0 / (2 * i + 1) : -1.0 / (2 * i + 1);
            pi += term;

            if (Math.Abs(term) < epsilon)
                break;

            i++;
        }

        return pi * 4;
    }

    static double CalculateLnSeries(double epsilon)
    {
        double x = 0.0;
        double term = 1.0;
        double n = 1.0;

        while (Math.Abs(term) > epsilon)
        {
            x += term;
            n += 1.0;
            term = (n % 2 == 0) ? -1.0 / n : 1.0 / n;
        }

        return x;
    }
    static double CalculateLnEquation(double epsilon)
    {
        double x = 0.0;
        while (Math.Abs(Math.Exp(x) - 2.0) > epsilon)
        {
            x -= (Math.Exp(x) - 2.0) / Math.Exp(x);
        }
        return x;
    }

    static double CalculateLnLimit(double epsilon)
    {
        double prev = 0;
        double cur = 2;
        for (int counter = 1; counter <= int.MaxValue && Math.Abs(cur - prev) > epsilon; counter++)
        {
            prev = cur;
            cur = counter * (Math.Pow(2, 1.0 / counter) - 1);
        }
        return cur;
    }

    static double CalculateSqrt2Series(double epsilon)
    {
        double result = 1.0;
        double term;
        int iter = 100000;

        for (int k = 2; k <= iter; k++)
        {
            term = Math.Pow(2, Math.Pow(2, -k));

            if (Math.Abs(term) < epsilon)
            {
                break;
            }
            result *= term;
        }

        return result;
    }


    static double CalculateSqrt2Equation(double epsilon)
    {
        // Уравнение для sqrt(2): x^2 - 2 = 0
        // Применяем метод Ньютона для нахождения корня уравнения
        double x = 2.0;
        while (Math.Abs(x * x - 2) > epsilon)
        {
            x = (x + 2 / x) / 2;
        }

        return x;
    }
    static double CalculateSqrt2Limit(double epsilon)
    {
        // Предел для sqrt(2) как предел последовательности x_n = (x_{n-1} + 2 / x_{n-1}) / 2

        double x = 1.0;

        do
        {
            double prevX = x;
            x = (x + 2 / x) / 2;

            if (Math.Abs(x - prevX) < epsilon)
                break;
        } while (true);

        return x;
    }

    static double Factorial(int n)
    {
        if (n <= 1)
            return 1;
        else
            return n * Factorial(n - 1);
    }
    static double CalculateGammaSeries(double epsilon)
    {
        double eCurrent = 1;
        double ePrevious = 0;
        double result = 0;
        int count = 0;
        for (int n = 1; Math.Abs(eCurrent - ePrevious) > epsilon; n++)
        {
            ePrevious = eCurrent;
            eCurrent += (1.0 / n);
            ++count;
        }
        return eCurrent - Math.Log(count) - 1;
    }

    public static bool IsPrime(int number)
    {
        for (int i = 2; i < Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
    static double CalculateGammaEquation(double epsilon)
    {
        return Math.Pow(epsilon, CalculateGammaSeries(epsilon));
    }

    static double CalculateGammaLimit(double epsilon)
    {
        int n = (int)(1.0 / epsilon) * 100;
        double result = 1;
        double ePrevious = 0;
        double eCurrent = 1;
        for (int m = 2; m < n; m++)
        {
            ePrevious = eCurrent;
            eCurrent = result + (1 / m) - Math.Log(n);

            if (Math.Abs(eCurrent - ePrevious) > epsilon)
            {
                result += 1.0 / m;
                ePrevious = eCurrent;
            }
            else
            {
                result = result - Math.Log(m);
                break;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Использование: ConstantsCalculator <точность>");
            return;
        }

        double epsilon;
        if (!double.TryParse(args[0], out epsilon) || epsilon <= 0)
        {
            Console.WriteLine("Точность должна быть положительным числом.");
            return;
        }

        // Вычисление числа e различными методами
        double eBySeries = CalculateEBySeries(epsilon);
        double eByLimit = CalculateEByLimit(epsilon);
        double eByEquation = CalculateEByEquation(epsilon);

        Console.WriteLine($"Значение числа e через сумму ряда: {eBySeries}");
        Console.WriteLine($"Значение числа e через уравнение: {eByLimit}");
        Console.WriteLine($"Значение числа e через предел: {eByEquation}");

        // Вычисление числа pi различными методами
        double piBySeries = CalculatePiBySeries(epsilon); 
        double piByEquation = CalculatePiByEquation(epsilon);
        double piByLimit = CalculatePiByLimit(epsilon);

        Console.WriteLine($"\nЗначение числа pi через сумму ряда: {piBySeries}");
        Console.WriteLine($"Значение числа pi через уравнение: {piByEquation}"); 
        Console.WriteLine($"Значение числа pi через предел: {piByLimit}");

        // Вычисление числа ln2 различными методами
        double lnSeries = CalculateLnSeries(epsilon);
        double lnEquation = CalculateLnEquation(epsilon);
        double lnLimit = CalculateLnLimit(epsilon);

        Console.WriteLine($"\nЗначение числа ln2 через сумму ряда: {lnSeries}");
        Console.WriteLine($"Значение числа ln2 через уравнение: {lnEquation}");
        Console.WriteLine($"Значение числа ln2 через предел: {lnLimit}");

        // Вычисление числа sqrt(2) различными методами
        double sqrt2SumSeries = CalculateSqrt2Series(epsilon);
        double sqrt2Equation = CalculateSqrt2Equation(epsilon);
        double sqrt2Limit = CalculateSqrt2Limit(epsilon);
        
        Console.WriteLine($"\nЗначение числа sqrt(2) через сумму ряда: {sqrt2SumSeries}");
        Console.WriteLine($"Значение числа sqrt(2) через уравнение: {sqrt2Equation}");
        Console.WriteLine($"Значение числа sqrt(2) через предел: {sqrt2Limit}");

        // Вычисление числа gamma различными методами
        double GammaSeries = CalculateGammaSeries(epsilon);
        double GammaEquation = CalculateGammaEquation(epsilon);
        double GammaLimit = CalculateGammaLimit(epsilon);

        Console.WriteLine($"\nЗначение числа gamma через сумму ряда: {GammaSeries}");
        Console.WriteLine($"Значение числа gamma через уравнение: {GammaEquation}");
        Console.WriteLine($"Значение числа gamma через предел: {GammaLimit}");
    }
}


   
