using AoC2020.Helpers;

namespace AoC2020.Days.Day03
{
    public class Day03 : BaseDay<string[]>
    {
        public Day03()
        {
            SetInput(FileParser.ReadFromFile(nameof(Day03)));
        }

        public override string SolvePartOne()
        {
            var x = 3;
            var y = 1;
            var current = (x, y);
            var rightBound = Input[0].Length;
            var trees = 0;

            while (y + current.y <= Input.Length)
            {
                if (current.x >= rightBound)
                    current.x -= rightBound;

                if (Input[current.y][current.x] == '#')
                {
                    trees++;
                }

                current.y++;
                current.x+=3;
            }

            return trees.ToString();
        }

        public override string SolvePartTwo()
        {
            throw new System.NotImplementedException();
        }
    }
}