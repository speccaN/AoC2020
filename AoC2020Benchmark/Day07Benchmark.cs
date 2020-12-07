using AoC2020.Days.Day07;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day07Benchmark : BaseDayBenchmark
    {
        readonly Day07 _problem = new Day07();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}