using AoC2020.Days.Day05;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day05Benchmark : BaseDayBenchmark
    {
        private readonly Day05 _problem = new Day05();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}