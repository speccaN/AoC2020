using System.Linq;

namespace AoC2020.Days.Day03
{
    public class Day03 : BaseDay
    {
        public override string SolvePartOne() => CalcTrees(Input, 3, 1).ToString();

        public override string SolvePartTwo() =>
            new (int x, int y)[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)}
                .Aggregate<(int right, int down), int>(1, (acc, x) => acc * CalcTrees(Input, x.right, x.down)).ToString();
        
        private static int CalcTrees(string[] input, int x, int y) =>
            input.Where((line, i) => i % y == 0 && line[x * (i / y) % line.Length] == '#').Count();
    }
}