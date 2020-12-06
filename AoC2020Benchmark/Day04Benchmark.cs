﻿using AoC2020.Days.Day04;

namespace AoC2020Benchmark
{
    public class Day04Benchmark : BaseDayBenchmark
    {
        private readonly Day04 _problem = new Day04();

        public override string Part1() => _problem.SolvePartOne();

        public override string Part2() => _problem.SolvePartTwo();
    }
}