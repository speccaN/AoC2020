using AoC2020.Days.Day12;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    public class Day12Benchmark : BaseDayBenchmark
    {
        private readonly Day12 _problem = new Day12();
        
        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}