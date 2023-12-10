using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the coefficients a, b, c, d for the equation ax^3 + bx^2 + cx + d = 0:");

        double a, b, c, d;
        if (double.TryParse(Console.ReadLine(), out a) &&
            double.TryParse(Console.ReadLine(), out b) &&
            double.TryParse(Console.ReadLine(), out c) &&
            double.TryParse(Console.ReadLine(), out d))
        {
            Console.WriteLine("The Cardano formula:");
            double[] rootsCardano = SolveCubicEquationCardano(a, b, c, d);
            PrintRoots(rootsCardano);

            Console.WriteLine("Without using the Cardano formula:");
            double[] rootsWithoutCardano = SolveCubicEquationWithoutCardano(a, b, c, d);
            PrintRoots(rootsWithoutCardano);
        }
        else
        {
            Console.WriteLine("Incorrect input.");
        }
    }

    static void PrintRoots(double[] roots)
    {
        Console.WriteLine("The roots of the equation:");
        foreach (double root in roots)
        {
            Console.WriteLine(root);
        }
        Console.WriteLine();
    }

    static double[] SolveCubicEquationCardano(double a, double b, double c, double d)
    {
        double[] roots = new double[3];

        double p = (3 * a * c - b * b) / (3 * a * a);
        double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);

        double discriminant = q * q / 4 + p * p * p / 27;

        if (discriminant > 0)
        {
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double u = Math.Pow(-q / 2 + sqrtDiscriminant, 1.0 / 3.0);
            double v = Math.Pow(-q / 2 - sqrtDiscriminant, 1.0 / 3.0);

            roots[0] = u + v - b / (3 * a);
        }
        else if (discriminant == 0)
        {
            double u = Math.Pow(-q / 2, 1.0 / 3.0);
            roots[0] = 2 * u - b / (3 * a);
            roots[1] = -u - b / (3 * a);
        }
        else
        {
            double rho = Math.Sqrt(-p * p * p / 27);
            double theta = Math.Acos(-q / (2 * rho));

            roots[0] = 2 * Math.Pow(rho, 1.0 / 3.0) * Math.Cos(theta / 3) - b / (3 * a);
            roots[1] = 2 * Math.Pow(rho, 1.0 / 3.0) * Math.Cos((theta + 2 * Math.PI) / 3) - b / (3 * a);
            roots[2] = 2 * Math.Pow(rho, 1.0 / 3.0) * Math.Cos((theta + 4 * Math.PI) / 3) - b / (3 * a);
        }

        return roots;
    }

    static double[] SolveCubicEquationWithoutCardano(double a, double b, double c, double d)
    {
        // We use Newton's method to find the roots
        // The initial values can be chosen arbitrarily, but they affect the convergence of the method
        double x0 = 0.0;
        double epsilon = 1e-6;

        // The iterative process of Newton's method
        while (true)
        {
            double fx = a * x0 * x0 * x0 + b * x0 * x0 + c * x0 + d;
            double fprime = 3 * a * x0 * x0 + 2 * b * x0 + c;

            double x1 = x0 - fx / fprime;

            // Checking for convergence
            if (Math.Abs(x1 - x0) < epsilon)
            {
                break;
            }

            x0 = x1;
        }

        // The found value x0 is one of the roots
        // Next, you can use the division of the synthetic division to obtain a quadratic equation

        double discriminant = b * b - 4 * a * (c + x0 * (3 * a * x0 + 2 * b));
        double sqrtDiscriminant = Math.Sqrt(Math.Abs(discriminant));

        double[] roots = new double[3];

        roots[0] = (-b + sqrtDiscriminant) / (2 * a);
        roots[1] = (-b - sqrtDiscriminant) / (2 * a);
        roots[2] = x0;

        return roots;
    }
}
