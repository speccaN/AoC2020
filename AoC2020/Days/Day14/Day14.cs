using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day14
{
    public class Day14 : BaseDay
    {
        public override string SolvePartOne()
        {
            var mem = new Dictionary<long, long>();
            var mask = string.Empty;

            foreach (var line in Input)
            {
                var split = line.Split("=", StringSplitOptions.TrimEntries);
                if (split[0] == "mask")
                {
                    mask = split[1];
                    continue;
                }

                var memIndex = long.Parse(split[0].Replace("mem", "").Replace("[", "").Replace("]", ""));
                mem[memIndex] =
                    long.Parse(split[1])
                        .ToBinaryString(mask.Length)
                        .Select((chr, i) => mask[i] != 'X' ? mask[i] : chr).BinaryStringToNumber();
            
            }

            return mem.Values.Sum().ToString();
        }

        public override string SolvePartTwo()
        {
            var mem = new Dictionary<long, long>();
            var mask = string.Empty;

            foreach (var line in Input)
            {
                var split = line.Split("=", StringSplitOptions.TrimEntries);
                if (split[0] == "mask")
                {
                    mask = split[1];
                    continue;
                }

                var reversedBinary = long.Parse(split[0].Replace("mem", "").Replace("[", "").Replace("]", ""))
                    .ToBinaryString(mask.Length)
                    .Select((chr, i) => mask[i] == '1' || mask[i] == 'X' ? mask[i] : chr)
                    .Reverse()
                    .ToArray();

                var floatingIndices = reversedBinary.Select((chr, i) => (chr, i)).Where(w => w.chr.Equals('X'))
                    .Select(s => s.i)
                    .ToArray();

                var allCombinations = Permutations.WithRepetition(new[] {'1', '0'}, floatingIndices.Length);
                foreach (var combination in allCombinations)
                {
                    for (var i = 0; i < floatingIndices.Length; i++)
                    {
                        reversedBinary[floatingIndices[i]] = combination[i];
                    }

                    mem[reversedBinary.Reverse().BinaryStringToNumber()] = long.Parse(split[1]);
                }
            }

            return mem.Values.Sum().ToString();
        }
    }

    public static class StringHelpers
    {
        public static long BinaryStringToNumber(this string str) => Convert.ToInt64(str, 2);

        public static long BinaryStringToNumber(this IEnumerable<char> chrEnumerable) =>
            BinaryStringToNumber(new string(chrEnumerable.ToArray()));
        
        public static string ToBinaryString(this long num, int length) => 
            Enumerable.Range(0, length - Convert.ToString(num, 2).Length)
                .Aggregate(new StringBuilder(), (sb, _) => sb.Append("0")).Append(Convert.ToString(num, 2)).ToString();
    }

    public static class Permutations
    {
        public static IEnumerable<T[]> WithRepetition<T>(IEnumerable<T> list, int length)
        {
            return length == 1
                ? list.Select(s => new[] {s})
                : WithRepetition<T>(list, length - 1).SelectMany(sm => list, (t1, t2) => t1.Concat(new[] { t2 }).ToArray());
        }
    }
}