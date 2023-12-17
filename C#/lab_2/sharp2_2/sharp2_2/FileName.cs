using System;
using System.Collections.Generic;
using System.Linq;

public class Combinatorics<T>
{
    public static IEnumerable<IEnumerable<T>> GenerateCombinationsWithRepetition(IEnumerable<T> input, int k, IEqualityComparer<T> comparer)
    {
        if (k == 0)
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            int count = 0;
            foreach (var item in input)
            {
                foreach (var result in GenerateCombinationsWithRepetition(input.Skip(count), k - 1, comparer))
                {
                    yield return new[] { item }.Concat(result);
                }
                count++;
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> GenerateCombinationsWithoutRepetition(IEnumerable<T> input, int k, IEqualityComparer<T> comparer)
    {
        if (k == 0)
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            int count = 0;
            foreach (var item in input)
            {
                foreach (var result in GenerateCombinationsWithoutRepetition(input.Skip(count + 1), k - 1, comparer))
                {
                    yield return new[] { item }.Concat(result);
                }
                count++;
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> GenerateSubsets(IEnumerable<T> input, IEqualityComparer<T> comparer)
    {
        int count = input.Count();
        for (int i = 0; i < (1 << count); i++)
        {
            yield return input.Where((x, j) => (i & (1 << j)) != 0).ToList();
        }
    }

    public static IEnumerable<IEnumerable<T>> GeneratePermutations(IEnumerable<T> input, IEqualityComparer<T> comparer)
    {
        if (input.Count() == 0)
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            int count = 0;
            foreach (var item in input)
            {
                foreach (var result in GeneratePermutations(input.Where((x, i) => i != count), comparer))
                {
                    yield return new[] { item }.Concat(result);
                }
                count++;
            }
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var input = new[] { 1, 2, 3, 4 };

        try
        {
            var combinationsWithRepetition = Combinatorics<int>.GenerateCombinationsWithRepetition(input, 2, EqualityComparer<int>.Default);
            Console.WriteLine("Combinations with repetition:");
            foreach (var combination in combinationsWithRepetition)
            {
                Console.WriteLine(string.Join(", ", combination));
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        try
        {
            var combinationsWithoutRepetition = Combinatorics<int>.GenerateCombinationsWithoutRepetition(input, 2, EqualityComparer<int>.Default);
            Console.WriteLine("Combinations without repetition:");
            foreach (var combination in combinationsWithoutRepetition)
            {
                Console.WriteLine(string.Join(", ", combination));
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        var subsets = Combinatorics<int>.GenerateSubsets(input, EqualityComparer<int>.Default);
        Console.WriteLine("Subsets:");
        foreach (var subset in subsets)
        {
            Console.WriteLine(string.Join(", ", subset));
        }

        var permutations = Combinatorics<int>.GeneratePermutations(input, EqualityComparer<int>.Default);
        Console.WriteLine("Permutations:");
        foreach (var permutation in permutations)
        {
            Console.WriteLine(string.Join(", ", permutation));
        }
    }
}