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

    // Вычисление значения числа e через уравнение e = lim(1 + 1/n)^n при n -> бесконечности
    public static double CalculateEByLimit(double epsilon)
    {
        double e = Math.Pow(1.0 + epsilon, 1.0 / epsilon);
        return e;
    }

    // Вычисление значения числа e через значение предела
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
        // Решение уравнения: pi = 4 * arctan(1)
        return 4 * Math.Atan(1);
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
        x = Math.Log(2);
        return x;
    }

    static double CalculateLnLimit(double epsilon)
    {
        // Предел ln(1 + x) при x -> 0 равен x
        return Math.Log(2);
    }

    static double CalculateSqrt2Series(double epsilon)
    {
        double result = 1.0;
        double term = 1.0;
        int n = 1;

        while (Math.Abs(term) > epsilon)
        {
            term *= -1.0 * (2 * n - 1) / (2 * n);
            result += term;
            n++;
        }

        return result * 2;
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

        double x = 1.0; // Начальное предположение

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
        double x = 5.0;
        double sum = 1.0 / x;
        double term = 1.0 / x;

        for (int n = 1; Math.Abs(term) >= epsilon; n++)
        {
            term = (1.0 / Factorial(n)) * Math.Pow((x / (1 + x)), n);
            sum += term;
        }

        return sum;
    }
    static double CalculateGammaEquation(double epsilon)
    {
        // Реализация уравнения Эйлера для Гамма-функции
        // Для примера используется формула Гаусса
        double x = 5.0;
        return Math.Exp(-x) * Math.Pow(x, x - 0.5) * Math.Sqrt(2 * Math.PI) * (1 + 1 / (12 * x) + 1 / (288 * x * x) - 139 / (51840 * x * x * x) - 571 / (2488320 * x * x * x * x));
    }

    static double CalculateGammaLimit(double epsilon)
    {
        // Реализация значения Гамма через предел Гаусса
        double x = 5.0;
        return Math.Sqrt(2 * Math.PI / x) * Math.Pow((x / Math.E), x);
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
        //double GammaSeries = CalculateGammaSeries(epsilon);
        //double GammaEquation = CalculateGammaEquation(epsilon);
        //double GammaLimit = CalculateGammaLimit(epsilon);

        //Console.WriteLine($"\nЗначение числа gamma через сумму ряда: {GammaSeries}");
        //Console.WriteLine($"Значение числа gamma через уравнение: {GammaEquation}");
        //Console.WriteLine($"Значение числа gamma через предел: {GammaLimit}");
    }
}


   
