using AoC2020.Days.Day09;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day09Benchmark : BaseDayBenchmark
    {
        private readonly Day09 _problem = new Day09();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}