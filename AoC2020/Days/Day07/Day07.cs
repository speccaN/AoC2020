using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day07
{
    public class Day07 : BaseDay
    {
        private Dictionary<string, HashSet<string>> _bags;

        public override string SolvePartOne()
        {
            _bags = Input
                .Select(line => line.Substring(0, line.Length - 1).Replace(" bags", "").Replace(" bag", ""))
                .ToDictionary(key => key.Split(" contain ")[0], val => val.Split(" contain ")[1].Split(", ").Select(c => c.Substring(2)).ToHashSet());

            var total = 0;
            foreach (var key in _bags.Keys)
            {
                if (HasShinyGold(key))
                    total++;
            }

            return total.ToString();
        }

        bool HasShinyGold(string str)
        {
            if (_bags[str].Contains("shiny gold"))
                return true;
            foreach (var hs in _bags[str])
            {
                if (hs == " other") continue;
                if (!HasShinyGold(hs))
                    continue;
                return true;
            }

            return false;
        }

        public override string SolvePartTwo()
        {
            _bags = Input
                .Select(line => line[..^1].Replace(" bags", "").Replace(" bag", ""))
                .ToDictionary(key => key.Split(" contain ")[0], val => val.Split(" contain ")[1].Split(", ").ToHashSet());

            return CalculatePartTwo("shiny gold").ToString();
        }

        int CalculatePartTwo(string str)
        {
            var total = 0;
            foreach (var val in _bags[str])
            {
                if (val != "no other")
                {
                    var amount = int.Parse(val.Substring(0, 1));
                    total += amount + amount * CalculatePartTwo(val.Substring(2));
                }
                else
                    break;
            }

            return total;
        }
    }
}