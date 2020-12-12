using AoC2020.Days.Day10;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day10Benchmark : BaseDayBenchmark
    {
        readonly Day10 _problem = new Day10();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}