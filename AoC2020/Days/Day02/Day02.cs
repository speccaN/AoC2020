using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day02
{
    public class Day02 : BaseDay
    {
        readonly List<((int x, int y) nums, string letter, string pass)> _input;
        int _valid { get; set; }

        public Day02()
        {
            _input = Input.Select(s => s.Split(" ")).Select(s =>
            {
                var nums = s[0].Split("-").Select(int.Parse).ToArray();
                return ((nums[0], nums[1]), s[1].Replace(":", ""), s[2]);
            }).ToList();
        }

        public override string SolvePartOne()
        {
            _valid = 0;
            foreach (var ((x, y), letter, pass) in _input)
            {
                var count = pass.Count(w => w == letter[0]);
                if (count >= x && count <= y)
                    _valid++;
            }

            return _valid.ToString();
        }

        public override string SolvePartTwo()
        {
            _valid = 0;

            foreach (var ((x, y), letter, pass) in _input)
            {
                if (pass[x - 1] == letter[0] ^ pass[y - 1] == letter[0])
                    _valid++;
            }

            return _valid.ToString();
        }
    }
}