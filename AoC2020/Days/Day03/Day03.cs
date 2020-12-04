using System.Linq;

namespace AoC2020.Days.Day03
{
    public class Day03 : BaseDay
    {
        public override string SolvePartOne() => CalcTrees(1, 3).ToString();

        public override string SolvePartTwo() =>
            new (int x, int y)[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)}.Select(s => CalcTrees(s.y, s.x))
                .Aggregate(1L, (a, b) => a * b).ToString();

        int CalcTrees(int moveY, int moveX)
        {
            var currentX = 0;
            var trees = 0;

            for (int y = 0; y < Input.Length; y += moveY)
            {
                if (Input[y][currentX % Input[y].Length] == '#')
                    trees++;
                currentX += moveX;
            }

            return trees;
        }
    }
}