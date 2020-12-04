using AoC2020.Days.Day03;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day03Benchmark : BaseDayBenchmark
    {
        private readonly Day03 _problem = new Day03();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}