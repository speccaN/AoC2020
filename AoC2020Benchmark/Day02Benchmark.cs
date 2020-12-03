using AoC2020.Days.Day02;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    [MemoryDiagnoser]
    public class Day02Benchmark : BaseDayBenchmark
    {
        private readonly Day02 _problem = new Day02();

        [Benchmark]
        public override string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public override string Part2() => _problem.SolvePartTwo();
    }
}