using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'palindromeIndex' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int palindromeIndex(string s)
    {
        // given a string of lowercase letters in the range ascii[a-z]
        // determine the index of a character that can be removed to make the string a palindrome
        // if the string is already a palindrome, return -1
        // we can do this by iterating through the string and checking if the characters at the corresponding indices are equal
        // if they are not equal, we can check if removing either character would make the string a palindrome
        // if removing either character would make the string a palindrome, we return the index of the character to be removed
        // otherwise, we return -1

        // Input:
        // the first line contains an integer q, the number of queries
        // each of the next q lines contains a query string s
        // 1 <= q <= 20
        // 1 <= length of s <= 10^5 + 5

        // Output:
        // for each query, print the index of the character to be removed to make the string a palindrome
        // if the string is already a palindrome, print -1

        // lets code
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                // Check if removing left character makes the string a palindrome
                if (IsPalindrome(s, left + 1, right))
                {
                    return left;
                }
                // Check if removing right character makes the string a palindrome
                if (IsPalindrome(s, left, right - 1))
                {
                    return right;
                }
                // If neither makes it a palindrome, return -1
                return -1;
            }

            left++;
            right--;
        }

        // If no mismatches, the string is already a palindrome
        return -1;
    }

    // Helper function to check if a substring is a palindrome
    private static bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
            {
                return false;
            }
            start++;
            end--;
        }
        return true;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.palindromeIndex(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
