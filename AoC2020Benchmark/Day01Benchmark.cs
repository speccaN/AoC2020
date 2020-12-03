using AoC2020.Days.Day01;
using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    [MemoryDiagnoser]
    public class Day01Benchmark : BaseDayBenchmark
    {
        private readonly Day01 _problem = new Day01();

        [Benchmark]
        public string Part1() => _problem.SolvePartOne();

        [Benchmark]
        public string Part2() => _problem.SolvePartTwo();

        [Benchmark]
        public string Part1_Linq() => _problem.SolvePartOne_Linq();

        [Benchmark]
        public string Part2_Linq() => _problem.SolvePartTwo_Linq();

        [Benchmark]
        public string Part2_HashSet() => _problem.SolvePartTwo_HashSet();
    }
}