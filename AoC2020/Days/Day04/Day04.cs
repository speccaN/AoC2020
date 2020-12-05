using AoC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day04
{
    public class Day04 : BaseDay
    {
        private readonly HashSet<string> _hs = new HashSet<string>{"ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt"};
        private static readonly HashSet<string> eclHS = new HashSet<string>{ "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        private readonly Dictionary<string, Func<string,bool>> _dc = new Dictionary<string, Func<string, bool>>
        {
            {"byr", s => int.TryParse(s, out int res) && res >= 1920 && res <= 2002},
            {"iyr", s => int.TryParse(s, out int res) && res >= 2010 && res <= 2020},
            {"eyr", s => int.TryParse(s, out int res) && res >= 2020 && res <= 2030},
            {"hgt", s =>
            {
                var unit = s.Substring(s.Length - 2);
                if (unit != "cm" && unit != "in") return false;
                var val =int.Parse(s.Substring(0, s.Length - 2));
                if(unit == "cm")
                    return val >= 150 && val <= 193;
                return val >= 59 && val <= 76;
            }},
            {"hcl", s => s[0] == '#' && s.Substring(1).Length == 6 && s.Substring(1).All(a => char.IsLetter(a) ? a >= 'a' && a <= 'f' : a >= '0' && a <= '9')},
            {"ecl", s => eclHS.Contains(s)},
            {"pid", s => s.Length == 9 && s.All(char.IsDigit)},
            {"cid", s => true}
        };

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
                var fl = Input[i].Replace("\r\n", " ").Split(" ").Select(s => s.Split(":")[0])
                    .Where(x => _hs.Contains(x)).ToArray();
                if (fl.Length == _hs.Count)
                    count++;
            }

            return count.ToString();
        }

        public override string SolvePartTwo()
        {
            var count = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                var exist = 0;
                var fl = Input[i].Replace("\r\n", " ").Split(" ").Select(s => s.Split(":")).ToArray();
                for (int j = 0; j < fl.Length; j++)
                {
                    if (_hs.Contains(fl[j][0]))
                        exist++;
                }

                if (exist != _hs.Count) continue;
                {
                    var valid = true;

                    for (int j = 0; j < fl.Length; j++)
                    {
                        if (_dc[fl[j][0]](fl[j][1])) continue;
                        valid = false;
                        break;
                    }
                    if (valid)
                        count++;
                }
            }

            return count.ToString();
        }
    }
}