using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Result
{
    /*
     * Complete the 'highestValuePalindrome' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER n
     *  3. INTEGER k
     */

    public static string highestValuePalindrome(string s, int n, int k)
    {
        if (k >= n)
            return new string('9', n);
        StringBuilder sb = new StringBuilder(s);
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int count = 0;
        for (int i = 0; i < n / 2; i++)
        {
            if (s[i] != s[n - i - 1])
            {
                count++;
                dict.Add(i, s[i] - s[n - i - 1]);
            }
            if (count > k)
                return "-1";
        }
        int freeChanges = k - count;
        int m = 0;
        while (freeChanges > 0 && m < n / 2)
        {
            if (dict.ContainsKey(m))
            {
                if (sb[m] == '9')
                {
                    sb[n - m - 1] = '9';
                }
                else if (sb[n - m - 1] == '9')
                {
                    sb[m] = '9';
                }
                else
                {
                    sb[n - m - 1] = '9';
                    sb[m] = '9';
                    freeChanges--;
                }
                dict.Remove(m);
            }
            if (sb[m] == '9')
            {
                m++;
                continue;
            }
            else if (freeChanges >= 2)
            {
                sb[n - m - 1] = '9';
                sb[m] = '9';
                freeChanges -= 2;
            }
            else
                break;
            m++;
        }
        if (freeChanges == 1 && n % 2 == 1)
            sb[n / 2] = '9';
        foreach (var item in dict)
        {
            if (item.Value > 0)
                sb[n - item.Key - 1] = (char)(sb[n - item.Key - 1] + item.Value);
            else
                sb[item.Key] = (char)(sb[item.Key] - item.Value);
        }

        return sb.ToString();
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

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string s = Console.ReadLine();

        string result = Result.highestValuePalindrome(s, n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
