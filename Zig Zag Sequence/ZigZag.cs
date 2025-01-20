using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        // Number of test cases
        int t = int.Parse(Console.ReadLine());
        for (int cs = 0; cs < t; cs++)
        {
            // Size of the array
            int n = int.Parse(Console.ReadLine());
            int[] a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            FindZigZagSequence(a, n);
        }
    }

    static void FindZigZagSequence(int[] a, int n)
    {
        // Sort the array
        Array.Sort(a);

        // Find the middle index
        int mid = (n - 1) / 2;

        // Swap the middle element with the last element
        int temp = a[mid];
        a[mid] = a[n - 1];
        a[n - 1] = temp;

        // Reverse only the elements from mid+1 to the end of the array
        int st = mid + 1;
        int ed = n - 1;
        while (st < ed)
        {
            temp = a[st];
            a[st] = a[ed];
            a[ed] = temp;
            st++;
            ed--;
        }

        // Print the zig-zag sequence
        Console.WriteLine(string.Join(" ", a));
    }
}
