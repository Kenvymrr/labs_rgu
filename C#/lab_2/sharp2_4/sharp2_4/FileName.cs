using System.Collections.Generic;
using System;
using System.Diagnostics;

public interface INumericalIntegrationMethod
{
    double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy);

    string MethodName { get; }
}

public class LeftRectangleMethod : INumericalIntegrationMethod
{
    public string MethodName => "This is method left rectangle";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int n = 1;
        double previousResult = 0;
        double currentResult = CalculateIntegral(function, lowerBound, upperBound, n);

        while (Math.Abs(currentResult - previousResult) > accuracy)
        {
            n *= 2;
            previousResult = currentResult;
            currentResult = CalculateIntegral(function, lowerBound, upperBound, n);
        }

        return currentResult;
    }

    private double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, int n)
    {
        double step = (upperBound - lowerBound) / n;
        double result = 0;

        for (int i = 0; i < n; i++)
        {
            double x = lowerBound + i * step;
            result += function(x);
        }

        result *= step;
        return result;
    }
}
public class RightRectangleMethod : INumericalIntegrationMethod
{
    public string MethodName => "This is method right rectangle";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int n = 1;
        double previousResult = 0;
        double currentResult = CalculateIntegral(function, lowerBound, upperBound, n);

        while (Math.Abs(currentResult - previousResult) > accuracy)
        {
            n *= 2;
            previousResult = currentResult;
            currentResult = CalculateIntegral(function, lowerBound, upperBound, n);
        }

        return currentResult;
    }

    private double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, int n)
    {
        double step = (upperBound - lowerBound) / n;
        double result = 0;

        for (int i = 1; i < n + 1; i++)
        {
            double x = lowerBound + i * step;
            result += function(x);
        }

        result *= step;
        return result;
    }
}
public class MediumRectangleMethod : INumericalIntegrationMethod
{
    public string MethodName => "This is method medium rectangle";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int n = 1;
        double previousResult = 0;
        double currentResult = CalculateIntegral(function, lowerBound, upperBound, n);

        while (Math.Abs(currentResult - previousResult) > accuracy)
        {
            n *= 2;
            previousResult = currentResult;
            currentResult = CalculateIntegral(function, lowerBound, upperBound, n);
        }

        return currentResult;
    }

    private double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, int n)
    {
        double step = (upperBound - lowerBound) / n;
        double result = 0;

        for (double i = 0.5; i < n + 0.5; i++)
        {
            double x = lowerBound + i * step;
            result += function(x);
        }

        result *= step;
        return result;
    }
}
public class TrapezoidRectangleMethod : INumericalIntegrationMethod
{
    public string MethodName => "This is method Trapezoid rectangle";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int n = 1;
        double previousResult = 0;
        double currentResult = CalculateIntegral(function, lowerBound, upperBound, n);

        while (Math.Abs(currentResult - previousResult) > accuracy)
        {
            n *= 2;
            previousResult = currentResult;
            currentResult = CalculateIntegral(function, lowerBound, upperBound, n);
        }

        return currentResult;
    }

    private double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, int n)
    {
        double step = (upperBound - lowerBound) / n;
        double result = 0;
        for (int i = 0; i < n; i++)
        {
            double x = lowerBound + i * step;
            result += function(x);

        }
        double last_x = lowerBound + n * step;
        result += (function(lowerBound) + function(last_x)) / 2;
        result *= step;
        return result;
    }
}
public class
SimpsonRectangleMethod : INumericalIntegrationMethod
{
    public string MethodName => "This is method Simpson";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int n = 1;
        double previousResult = 0;
        double currentResult = CalculateIntegral(function, lowerBound, upperBound, n);

        while (Math.Abs(currentResult - previousResult) > accuracy)
        {
            n *= 2;
            previousResult = currentResult;
            currentResult = CalculateIntegral(function, lowerBound, upperBound, n);
        }

        return currentResult;
    }

    private double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, int n)
    {
        double step = (upperBound - lowerBound) / (2 * n);
        double result = 0;
        for (int i = 0; i < 2 * n; i++)
        {
            double x = lowerBound + i * step;
            if (i % 2 == 0)
            {
                result += 2 * function(x);
            }
            else
            {
                result += 4 * function(x);
            }

        }
        double last_x = lowerBound + 2 * n * step;
        result += function(lowerBound) + function(last_x);
        result *= step / 3;
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        double lowerBound = 2;
        double upperBound = 5;
        double accuracy = 0.00001;

        List<INumericalIntegrationMethod> methods = new List<INumericalIntegrationMethod>()
{
new LeftRectangleMethod(),
new RightRectangleMethod(),
new MediumRectangleMethod(),
new TrapezoidRectangleMethod(),
new SimpsonRectangleMethod()
};

        foreach (var method in methods)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            double result = method.CalculateIntegral(Function, lowerBound, upperBound, accuracy);

            stopwatch.Stop();

            Console.WriteLine($"{method.MethodName}: {result}, Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    static double Function(double x)
    {
        return 1 / Math.Log(x);
    }
}