using AoC2020.Days.Day15;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day15Benchmark : BaseDayBenchmark
    {
        private readonly Day15 _problem = new();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}