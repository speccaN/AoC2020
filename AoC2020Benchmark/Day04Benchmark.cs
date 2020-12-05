using AoC2020.Days.Day04;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day04Benchmark : BaseDayBenchmark
    {
        private readonly Day04 _problem = new Day04();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}