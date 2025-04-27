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
     * Complete the 'steadyGene' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING gene as parameter.
     */

    public static int steadyGene(string gene)
    {
        var occ = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'G', 0 },
            { 'C', 0 },
            { 'T', 0 },
        };
        foreach (var a in gene)
        {
            occ[a]++;
        }
        var extras = new Dictionary<char, int>();
        foreach (var a in occ)
        {
            if (a.Value > gene.Length / 4)
                extras[a.Key] = a.Value - gene.Length / 4;
        }
        if (extras.Count == 0)
            return 0;
        int left = 0;
        int result = gene.Length;
        for (int right = 0; right < gene.Length; right++)
        {
            if (extras.ContainsKey(gene[right]))
                extras[gene[right]]--;
            while (extras.All(kvp => kvp.Value <= 0))
            {
                result = Math.Min(result, right - left + 1);
                if (extras.ContainsKey(gene[left]))
                    extras[gene[left]]++;
                left++;
            }
        }
        return result;
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

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string gene = Console.ReadLine();

        int result = Result.steadyGene(gene);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
