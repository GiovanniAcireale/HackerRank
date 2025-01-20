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
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        // so given 5 positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers
        // we can do this by sorting the array and summing the first four elements to get the minimum sum and the last four elements to get the maximum sum
        // beware of integer overflow, use 64-bit integers

        // sort the array
        arr.Sort();

        // calculate the minimum and maximum sums
        long minSum = 0, maxSum = 0;
        for (int i = 0; i < 4; i++)
        {
            minSum += arr[i];
            maxSum += arr[i + 1];
        }

        // print the results
        Console.WriteLine($"{minSum} {maxSum}");


    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
