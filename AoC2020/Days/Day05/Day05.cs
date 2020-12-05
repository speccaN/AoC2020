using System.Linq;

namespace AoC2020.Days.Day05
{
    public class Day05 : BaseDay
    {
        public Day05()
        {
            InitInput();
        }

        public override string SolvePartOne()
        {
            var result = Input.Select(line => line.Aggregate(0, (acc, c) => 
                (acc<<1) + (c=='B' || c=='R' ? 1 : 0)))
                .OrderBy(x => x)
                .ToList();

            return result.Last().ToString();
        }

        public override string SolvePartTwo()
        {
            var result = Input.Select(line => line.Aggregate(0, (acc, c) =>
                    (acc << 1) + (c == 'B' || c == 'R' ? 1 : 0)))
                .OrderBy(x => x)
                .ToList();

            var i = result
                .Zip(result.Skip(1), (a, b) => (a, b))
                .First(f => f.a + 2 == f.b)
                .a + 1;

            return i.ToString();
        }
    }
}