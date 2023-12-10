using System;

class Program
{
    public delegate double EquationDelegate(double x);

    public static double FindRoot(double a, double b, EquationDelegate equation, double epsilon)
    {
        if (equation(a) * equation(b) > 0)
        {
            throw new ArgumentException("At a given interval, the function does not change its sign, the root cannot be found by dichotomy.");
        }

        int maxIterations = 10000; // Увеличиваем количество итераций
        double c = 0;

        for (int i = 0; i < maxIterations; i++)
        {
            c = (a + b) / 2;

            if (Math.Abs(equation(c)) < epsilon)
            {
                return c;
            }
            else if (equation(c) * equation(a) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
        }

        return c;
    }

    static void Main()
    {
        Console.WriteLine("Test 1: x^2 - 4 = 0");
        EquationDelegate equation1 = x => x * x - 4;
        double root1 = FindRoot(0, 3, equation1, 0.001);
        Console.WriteLine($"Root: {root1}");

        Console.WriteLine("\nTest 2: cos(x) - x = 0");
        EquationDelegate equation2 = x => Math.Cos(x) - x;
        double root2 = FindRoot(0, 1, equation2, 0.001);
        Console.WriteLine($"Root: {root2}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
