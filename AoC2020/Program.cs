using AoC2020.Days.Day01;
using AoC2020.Days.Day02;
using AoC2020.Days.Day03;
using AoC2020.Helpers;
using System;
using System.Linq;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Day03 d3 = new Day03();
            d3.SolvePartOne();
            //Day01 d1 =  new Day01();
            //ConsoleWriter.PrintDayToConsole(nameof(Day01));
            //foreach (var methodInfo in d1.GetType().GetMethods().Where(w => w.IsVirtual && w.DeclaringType == d1.GetType()))
            //{
            //    var result = (string) methodInfo.Invoke(d1, null);
            //    ConsoleWriter.PrintToConsole(methodInfo.Name, result);
            //    ConsoleWriter.PrintProblemSeparator();
            //}
            //ConsoleWriter.PrintDaySeparator();
        }
    }
}
