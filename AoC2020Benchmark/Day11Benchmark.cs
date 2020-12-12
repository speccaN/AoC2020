using AoC2020.Days.Day11;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day11Benchmark : BaseDayBenchmark
    {
        private readonly Day11 _problem = new Day11();
        
        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}