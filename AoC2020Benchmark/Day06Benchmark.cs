using AoC2020.Days.Day06;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day06Benchmark : BaseDayBenchmark
    {
        private readonly Day06 _problem = new Day06();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}