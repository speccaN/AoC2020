using AoC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day06
{
    public class Day06 : BaseDay
    {

        public Day06()
        {
            SetInput(FileParser.ReadAllText(GetType().Name).Split(new[] { Environment.NewLine + Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries));
        }

        public override string SolvePartOne()
        {
            return Input
                .Select(line => line.Replace(Environment.NewLine, "")
                    .ToHashSet())
                .Aggregate(0, (i, set) => i + set.Count)
                .ToString();
        }

        public override string SolvePartTwo()
        {
            return Input
                .Select(line =>
                    line.Split(Environment.NewLine)
                        .Aggregate((first, second) => string.Join("", first.Intersect(second)))).Sum(s => s.Length).ToString();
                //.Aggregate(0, (i, s) => i += s.Length).ToString();
        }
    }
}