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
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        // given a square matrix, find the absolute difference between the sums of its diagonals
        // the primary diagonal is the diagonal from the top-left to the bottom-right
        // the secondary diagonal is the diagonal from the top-right to the bottom-left
        // we can do this by iterating through the matrix and summing the elements at the primary and secondary diagonal positions
        // then return the absolute difference between the two sums

        int n = arr.Count; // the number of rows in the matrix
        int primarySum = 0, secondarySum = 0; // initialize the sums
        for (int i = 0; i < n; i++)
        {
            primarySum += arr[i][i];
            // the primary diagonal has the same row and column index

            secondarySum += arr[i][n - i - 1];
            // the secondary diagonal has the same row index and the column index is the total number of rows minus the current row index minus 1
        }

        return Math.Abs(primarySum - secondarySum);
        // return the absolute difference between the two sums
        // the absolute difference is the positive difference between the two sums
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
