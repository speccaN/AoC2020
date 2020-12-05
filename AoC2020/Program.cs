using AoC2020.Days;
using AoC2020.Days.Day04;
using AoC2020.Days.Day05;
using System;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseDay d5 = new Day05();
            Console.WriteLine(d5.SolvePartOne());
            Console.WriteLine(d5.SolvePartTwo());
        }
    }
}
