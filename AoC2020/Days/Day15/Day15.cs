using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day15
{
    public class Day15 : BaseDay
    {
        private readonly uint[] _input = {1, 20, 11, 6, 12, 0};

        public override string SolvePartOne()
        {
            return VanEck(_input, 2020);
        }

        public override string SolvePartTwo()
        {
            return VanEck(_input, 30_000_000);
        }

        public static string VanEck(uint[] input, uint TURNS)
        {
            var seen = new uint[TURNS];
            var gamesize = input.Length;

            uint i, j, lastnum = input[gamesize - 1];

            i = 1;
            while (i < gamesize)
            {
                seen[input[i - 1]] = i;
                i++;
            }

            while (i < TURNS)
            {
                j = seen[lastnum];
                seen[lastnum] = i;
                lastnum = j == 0 ? 0 : i - j;
                i++;
            }

            return lastnum.ToString();
        }
    }
}