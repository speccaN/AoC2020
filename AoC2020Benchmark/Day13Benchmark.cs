using AoC2020.Days.Day13;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day13Benchmark : BaseDayBenchmark
    {
        private readonly Day13 _problem = new Day13();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}