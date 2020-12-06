using AoC2020.Days.Day06;

namespace AoC2020Benchmark
{
    public class Day06Benchmark : BaseDayBenchmark
    {
        private readonly Day06 _problem = new Day06();

        public override string Part1() => _problem.SolvePartOne();

        public override string Part2() => _problem.SolvePartTwo();
    }
}