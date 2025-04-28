using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Result
{
    static int[] blue = new int[26];
    static int[] green = new int[26];
    static int count = 0;

    /*
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int sherlockAndAnagrams(string s)
    {
        count = 0;
        for (int window = 1; window <= s.Length - 1; window++)
        {
            for (int blueLeft = 0; blueLeft <= s.Length - window - 1; blueLeft++)
            {
                Array.Clear(blue);
                for (int indexBlue = blueLeft; indexBlue < blueLeft + window; indexBlue++)
                {
                    blue[s[indexBlue] - 'a']++;
                }
                for (int greenLeft = blueLeft + 1; greenLeft <= s.Length - window; greenLeft++)
                {
                    Array.Clear(green);
                    for (int indexGreen = greenLeft; indexGreen < greenLeft + window; indexGreen++)
                    {
                        green[s[indexGreen] - 'a']++;
                    }
                    bool areEqual = true;
                    for (int i = 0; i < green.Length; i++)
                    {
                        if (blue[i] != green[i])
                        {
                            areEqual = false;
                            break;
                        }
                    }
                    if (areEqual)
                        count++;
                }
            }
        }
        return count;
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

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
