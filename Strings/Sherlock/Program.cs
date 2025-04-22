using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'isValid' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isValid(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            if (dict.ContainsKey(ch))
            {
                dict[ch]++;
            }
            else
            {
                dict.Add(ch, 1);
            }
        }
        //double validOccur1 = s.Length/(double)dict.Count;
        double validOccur2 = (s.Length - 1) / (double)(dict.Count - 1);
        double validOccur3 = (s.Length / (double)dict.Count - 1 / (double)dict.Count);
        //bool valid1 = true;
        bool valid2 = true;
        bool valid3 = true;
        foreach (int val in dict.Values)
        {
            //if(val != validOccur1) valid1 = false;
            if (val != validOccur2 && val != 1)
                valid2 = false;
            if (val < validOccur3 || val > validOccur3 + 1)
                valid3 = false;
            if (!(valid2 || valid3))
                return $"NO";
        }
        return $"YES";
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

        string result = Result.isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
