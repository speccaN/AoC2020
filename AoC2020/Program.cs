using AoC2020.Days.Day03;
using System;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Day03 d3 = new Day03();
            Console.WriteLine(d3.SolvePartOne());
            Console.WriteLine(d3.SolvePartTwo());
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
