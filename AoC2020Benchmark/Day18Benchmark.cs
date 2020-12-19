using AoC2020.Days.Day18;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day18Benchmark : BaseDayBenchmark
    {
        private readonly Day18 _problem = new();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}