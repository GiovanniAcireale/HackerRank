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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        int n = arr.Count;
        
        // count of positive, negative and zero elements
        // flex on em with the lambda expressions in one line
        int pos = arr.Count(x => x > 0), neg = arr.Count(x => x < 0), zero = arr.Count(x => x == 0);
        // the line above works by counting the elements that satisfy the condition x > 0, x < 0 and x == 0 within the list arr

        // calculate the ratios
        double posRatio = (double)pos / n, negRatio = (double)neg / n, zeroRatio = (double)zero / n;
        // we cast the numerator to double to get a double result, otherwise the division would be an integer division

        // print the ratios with six decimal places

        // this would be the simple approach
        //Console.WriteLine(posRatio.ToString("0.000000"));
        //Console.WriteLine(negRatio.ToString("0.000000"));
        //Console.WriteLine(zeroRatio.ToString("0.000000"));

        //now we adding some zest to it
        //Console.WriteLine(posRatio.ToString("F6"));
        //Console.WriteLine(negRatio.ToString("F6"));
        //Console.WriteLine(zeroRatio.ToString("F6"));

        // and now we are flexing on them with the interpolated strings
        Console.WriteLine($"{posRatio:F6}\n{negRatio:F6}\n{zeroRatio:F6}");


    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}