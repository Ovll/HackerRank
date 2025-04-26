using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class Result
{
    /*
     * Complete the 'commonChild' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

    public static int commonChild(string s1, string s2)
    {
        int[] row = new int[s2.Length + 1];
        int prev,
            temp;
        for (int i = 1; i <= s1.Length; i++)
        {
            prev = 0;
            for (int j = 1; j <= s2.Length; j++)
            {
                temp = row[j];
                if (s2[i - 1] == s1[j - 1])
                    row[j] = prev + 1;
                else
                    row[j] = Math.Max(row[j], row[j - 1]);
                prev = temp;
            }
        }
        return row[s2.Length];
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

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = Result.commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
