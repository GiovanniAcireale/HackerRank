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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        // Caesar cipher is a type of substitution cipher in which each letter in the plaintext is shifted a certain number of places down the alphabet
        // we can implement this by iterating through the string and shifting each letter by k places
        // we need to consider the case where the shift goes beyond the end of the alphabet
        // we can do this by using the modulo operator to wrap around the alphabet

        /*
        // create a StringBuilder to store the result
        StringBuilder result = new StringBuilder();

        // iterate through the string
        foreach (char c in s)
        {
            // check if the character is a letter
            if (char.IsLetter(c))
            {
                // get the ASCII value of the character
                int ascii = (int)c;

                // determine the case of the letter
                bool isUpper = char.IsUpper(c);

                // shift the character by k places
                ascii += k;

                // wrap around the alphabet if necessary
                if (isUpper)
                {
                    if (ascii > 'Z')
                    {
                        ascii = 'A' + (ascii - 'Z' - 1);
                    }
                }
                else
                {
                    if (ascii > 'z')
                    {
                        ascii = 'a' + (ascii - 'z' - 1);
                    }
                }

                // append the shifted character to the result
                result.Append((char)ascii);
            }
            else
            {
                // append non-letter characters as is
                result.Append(c);
            }
        }

        // return the result as a string
        return result.ToString();
        */

        // the above implementation failed due to a calculation error in some test cases
        // to fix it, we need to reduce k to within the range of 0-25 before shifting the characters
        k = k % 26;

        // Create a StringBuilder to store the result
        StringBuilder result = new StringBuilder();

        // Iterate through the string
        foreach (char c in s)
        {
            // Check if the character is a letter
            if (char.IsLetter(c))
            {
                // Determine the starting ASCII value based on case
                char baseChar = char.IsUpper(c) ? 'A' : 'a';

                // Shift the character and wrap around using modulo
                char shiftedChar = (char)((c - baseChar + k) % 26 + baseChar);

                // Append the shifted character to the result
                result.Append(shiftedChar);
            }
            else
            {
                // Append non-letter characters as is
                result.Append(c);
            }
        }

        // Return the result as a string
        return result.ToString();
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
