using System;
using System.Numerics;

public static class NumberTheory
{
    public static BigInteger ModPow(BigInteger baseValue, BigInteger exponent, BigInteger modulus)
    {
        if (modulus == 1)
            return 0;

        BigInteger result = 1;
        baseValue = baseValue % modulus;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
                result = (result * baseValue) % modulus;

            exponent >>= 1;
            baseValue = (baseValue * baseValue) % modulus;
        }

        return result;
    }

    public static BigInteger Gcd(BigInteger a, BigInteger b)
    {
        while (b != 0)
        {
            BigInteger temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static BigInteger JacobiSymbol(BigInteger a, BigInteger n)
    {
        if (n <= 0 || n % 2 == 0)
            throw new ArgumentException("Second argument of Jacobi symbol must be a positive odd integer.");

        if (a < 0 || a >= n)
            a = a % n + n;

        if (a == 0)
            return (n == 1) ? 1 : 0;

        BigInteger result = 1;

        while (a != 0)
        {
            while (a % 2 == 0)
            {
                a /= 2;
                BigInteger r = n % 8;
                if (r == 3 || r == 5)
                    result = -result;
            }

            BigInteger temp = a;
            a = n;
            n = temp;

            if (a % 4 == 3 && n % 4 == 3)
                result = -result;

            a %= n;
        }

        if (n != 1)
            return 0;

        return result;
    }
}

public interface IPrimalityTest
{
    bool IsPrime(BigInteger number, double accuracy);
}

public abstract class ProbabilisticPrimalityTest : IPrimalityTest
{
    protected Random random = new Random();

    public abstract bool IsPrime(BigInteger number, double accuracy);

    public int GetIterationCount(double accuracy)
    {
        return (int)Math.Ceiling(-Math.Log(1 - accuracy) / Math.Log(2));
    }

    public void RunTestLoop(BigInteger number, double accuracy)
    {
        int iterations = GetIterationCount(accuracy);

        for (int i = 0; i < iterations; i++)
        {
            bool result = IsPrime(number, accuracy);
            Console.WriteLine($"Iteration {i + 1}: {result}");
        }
    }
}

public class DeterministicPrimalityTest : IPrimalityTest
{
    public bool IsPrime(BigInteger number, double Probability)
    {
        if (number <= 0)
        {
            throw new ArgumentException("Value can't be lower or equal to 0", nameof(number));
        }
        if (number == 1)
        {
            throw new ArgumentException("Value 1 is not prime nor composite", nameof(number));
        }
        if (number <= 3)
        {
            return true;
        }
        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (int count = 5; count * count <= number; count += 2)
        {
            if (number % count == 0)
            {
                return false;
            }
        }
        return true;
    }
}

public class FermatPrimalityTest : ProbabilisticPrimalityTest
{
    public override bool IsPrime(BigInteger number, double accuracy)
    {
        int iterations = GetIterationCount(accuracy);

        for (int i = 0; i < iterations; i++)
        {
            BigInteger a = random.Next(2, (int)(number - 1));
            if (NumberTheory.ModPow(a, number - 1, number) != 1)
                return false;
        }

        return true;
    }
}

public class SolovayStrassenPrimalityTest : ProbabilisticPrimalityTest
{
    private new readonly Random random = new Random();

    public override bool IsPrime(BigInteger number, double accuracy)
    {
        int iterations = GetIterationCount(accuracy);

        if (number <= 1)
            return false;

        if (number == 2 || number == 3)
            return true;

        if (number % 2 == 0)
            return false;

        for (int i = 0; i < iterations; i++)
        {
            BigInteger a = RandomBigInteger(2, number - 1);
            BigInteger jacobiSymbol = NumberTheory.JacobiSymbol(a, number);
            BigInteger modPowResult = NumberTheory.ModPow(a, (number - 1) / 2, number);

            if (jacobiSymbol == 0 || modPowResult != jacobiSymbol % number)
                return false;
        }

        return true;
    }

    private BigInteger RandomBigInteger(BigInteger min, BigInteger max)
    {
        byte[] data = new byte[max.ToByteArray().Length];
        random.NextBytes(data);

        BigInteger result = new BigInteger(data);
        result = BigInteger.Remainder(result, max - min);

        return result + min;
    }
}

public class MillerRabinPrimalityTest : ProbabilisticPrimalityTest
{
    public override bool IsPrime(BigInteger number, double accuracy)
    {
        if (number == 2 || number == 3)
            return true;

        if (number < 2 || number % 2 == 0)
            return false;

        BigInteger d = number - 1;
        int s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s++;
        }

        int iterations = GetIterationCount(accuracy);

        for (int i = 0; i < iterations; i++)
        {
            BigInteger a = random.Next(2, (int)(number - 1));
            BigInteger x = NumberTheory.ModPow(a, d, number);

            if (x == 1 || x == number - 1)
                continue;

            for (int j = 0; j < s - 1; j++)
            {
                x = NumberTheory.ModPow(x, 2, number);
                if (x == 1)
                    return false;

                if (x == number - 1)
                    break;
            }

            if (x != number - 1)
                return false;
        }

        return true;
    }
}

class Program
{
    static void Main()
    {
        BigInteger numberToTest = 997; 

        IPrimalityTest deterministicTest = new DeterministicPrimalityTest();
        IPrimalityTest fermatTest = new FermatPrimalityTest();
        IPrimalityTest solovayStrassenTest = new SolovayStrassenPrimalityTest();
        IPrimalityTest millerRabinTest = new MillerRabinPrimalityTest();

        double accuracy = 0.00001; 

        Console.WriteLine($"Deterministic Test: {deterministicTest.IsPrime(numberToTest, accuracy)}");
        Console.WriteLine($"Fermat Test: {fermatTest.IsPrime(numberToTest, accuracy)}");
        Console.WriteLine($"Solovay-Strassen Test: {solovayStrassenTest.IsPrime(numberToTest, accuracy)}");
        Console.WriteLine($"Miller-Rabin Test: {millerRabinTest.IsPrime(numberToTest, accuracy)}");

        // Пример запуска цикла тестирования
        //ProbabilisticPrimalityTest test = new MillerRabinPrimalityTest();
        //test.RunTestLoop(numberToTest, accuracy);
    }
}
