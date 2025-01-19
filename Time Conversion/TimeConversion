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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        // given a time in 12-hour am/pm format, convert it to military (24-hour) time
        // sample input: 07:05:45PM
        // sample output: 19:05:45
        // A single string s that represents a time in 12-hour clock format (i.e.: hh:mm:ssAM or hh:mm:ssPM).

        // we can do this by checking if the time is in the AM or PM and then converting the hours accordingly
        // if the time is in the AM, we can just remove the AM and if the time is in the PM, we can add 12 to the hours and remove the PM
        // show it

        // check if the time is in the AM or PM
        bool isPM = s.Contains("PM");

        // remove the AM or PM
        s = s.Replace("AM", "").Replace("PM", "");

        // split the time into hours, minutes and seconds
        string[] time = s.Split(':');

        // convert the hours to military time and account for 12:00:00AM and 12:00:00PM
        int hours = int.Parse(time[0]);
        if (isPM && hours != 12)
        {
            hours += 12;
        }
        else if (!isPM && hours == 12)
        {
            hours = 0;
        }

        // return the military time
        return $"{hours:D2}:{time[1]}:{time[2]}";


    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
