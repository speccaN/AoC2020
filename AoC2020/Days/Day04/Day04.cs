using AoC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day04
{
    public class Day04 : BaseDay
    {
        private readonly string[] _arr = {"ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt"};

        public Day04()
        {
            SetInput(FileParser.ReadAllText(GetType().Name).Split(new[] {Environment.NewLine + Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries));
        }

        public override string SolvePartOne()
        {
            var count = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                var valid = true;
                var fl = Input[i].Replace("\r\n", " ").Split(" ").Select(s => s.Split(":")[0]).ToHashSet();
                for (int j = 0; j < _arr.Length; j++)
                {
                    if (fl.Contains(_arr[j])) continue;
                    if (_arr[j] == "cid") continue;
                    valid = false;
                    break;
                }

                if (valid)
                    count++;
            }

            return count.ToString();
        }

        public override string SolvePartTwo()
        {
            throw new System.NotImplementedException();
        }
    }
}