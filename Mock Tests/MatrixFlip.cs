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
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        // given a 2n x 2n matrix, where each cell contains an integer, we can perform one of two operations on the matrix:
        // 1. Choose a 2 x 2 submatrix and rotate it 90 degrees clockwise
        // 2. Choose a 2 x 2 submatrix and rotate it 90 degrees counterclockwise
        // we want to find the maximum sum of the integers in the matrix after performing the operations
        // we can do this by iterating through the matrix and selecting the maximum value from each pair of corresponding elements
        // then summing the maximum values

        int n = matrix.Count / 2; // the number of rows in the matrix
        int sum = 0; // initialize the sum

        // iterate through the matrix
        for (int i = 0; i < n; i++)
        {
            // i is the row index of the submatrix
            for (int j = 0; j < n; j++)
            {
                // j is the column index of the submatrix
                // We are in The Matrix.

                // select the maximum value from each pair of corresponding elements
                sum += Math.Max(Math.Max(matrix[i][j], matrix[i][2 * n - j - 1]), Math.Max(matrix[2 * n - i - 1][j], matrix[2 * n - i - 1][2 * n - j - 1]));
                // this is the maximum value from the four elements in the submatrix
                // the four elements are matrix[i][j], matrix[i][2 * n - j - 1], matrix[2 * n - i - 1][j], matrix[2 * n - i - 1][2 * n - j - 1]
                // 2 * n - j - 1 is the column index of the element in the same row but in the second half of the matrix
                // 2 * n - i - 1 is the row index of the element in the same column but in the second half of the matrix

            }
        }

        return sum;
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 2 * n; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            int result = Result.flippingMatrix(matrix);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
