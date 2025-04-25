using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class Result
{
    /*
     * Complete the 'initialize' function below.
     *
     * The function accepts STRING s as parameter.
     */

    // static string str;
    static long m = 1000000007;
    static int max = 50000;
    static long[] fact = new long[max + 1];
    static long[] inv = new long[max + 1];
    static List<int[]> input = new List<int[]>();

    public static void initialize(string s)
    {
        // This function is called once before all queries.
        input.Clear();
        input.Add(new int[26]);
        for (int i = 0; i < s.Length; i++)
        {
            input.Add((int[])input[i].Clone());
            input[i + 1][s[i] - 'a']++;
        }
        fact[0] = 1;
        fact[1] = 1;
        for (int i = 2; i < max + 1; i++)
        {
            fact[i] = fact[i - 1] * i % m;
        }
        inv[max] = modInvers(fact[max]);
        for (int a = max - 1; a >= 0; a--)
        {
            inv[a] = inv[a + 1] * (a + 1) % m;
        }
    }

    static long modInvers(long k)
    {
        return power(k, m - 2);
    }

    static long power(long x, long y)
    {
        long p = 1;
        x = x % m;
        while (y > 0)
        {
            if (y % 2 == 1)
                p = (p * x) % m;
            x = (x * x) % m;
            y >>= 1;
        }
        return p;
    }

    /*
     * Complete the 'answerQuery' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER l
     *  2. INTEGER r
     */

    public static int answerQuery(int l, int r)
    {
        // Return the answer for this query modulo 1000000007

        int[] test = new int[26];
        Dictionary<int, int> powers = new Dictionary<int, int>();

        for (int c = 0; c < 26; c++)
        {
            test[c] = input[r][c] - input[l - 1][c];
        }

        long result = 1;
        int count = 0;
        int countCenter = 0;

        foreach (var val in test)
        {
            if (val % 2 == 1)
                countCenter++;
            if (val > 1)
            {
                count += val / 2;
                if (powers.ContainsKey(val / 2))
                    powers[val / 2]++;
                else
                    powers.Add(val / 2, 1);
            }
        }

        foreach (var item in powers)
        {
            if (item.Key > 1)
            {
                result = result * power(inv[item.Key], item.Value) % m;
            }
        }
        result = result * fact[count] % m;

        if (countCenter != 0)
            result = result * countCenter % m;

        return (int)result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(
            @System.Environment.GetEnvironmentVariable("OUTPUT_PATH"),
            true
        );

        string s = Console.ReadLine();

        Result.initialize(s);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int l = Convert.ToInt32(firstMultipleInput[0]);

            int r = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.answerQuery(l, r);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
