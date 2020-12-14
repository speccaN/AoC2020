using AoC2020.Days.Day14;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day14Benchmark : BaseDayBenchmark
    {
        private readonly Day14 _problem = new Day14();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}