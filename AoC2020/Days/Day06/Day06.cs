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
            var a = Input
                .Select(line =>
                    line.Split(Environment.NewLine)
                        .Aggregate((first, second) => new string(first.Intersect(second).ToArray())))
                .Aggregate(0, (i, s) => i + s.Length).ToString();

            return Input
                .Select(line =>
                    line.Split(Environment.NewLine).Select(x => x)
                        .Aggregate((first, second) => string.Join("", first.Intersect(second))))
                .Aggregate(0, (i, s) => i += s.Length).ToString();
        }
    }
}