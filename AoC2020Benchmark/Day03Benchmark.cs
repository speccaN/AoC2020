using AoC2020.Days.Day03;

namespace AoC2020Benchmark
{
    public class Day03Benchmark : BaseDayBenchmark
    {
        private readonly Day03 _problem = new Day03();

        public override string Part1() => _problem.SolvePartOne();

        public override string Part2() => _problem.SolvePartTwo();
    }
}