using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day10
{
    public class Day10 : BaseDay
    {
        private readonly Dictionary<long, long> _resultDictionary = new Dictionary<long, long>();
        public override string SolvePartOne()
        {
            var newList = Input.Select(int.Parse).Append(0).OrderBy(o => o);

            var groupBy = newList.Zip(newList.Skip(1), (first, second) => second - first).GroupBy(g => g)
                .Select(s => (s.Key, s.Count())).ToArray();
            var total = groupBy[0].Item2 * (groupBy[1].Item2 + 1);

            return total.ToString();
        }

        public override string SolvePartTwo()
        {
            var sortedInput = Input.Select(long.Parse).OrderBy(o => o).ToArray();
            var parsedInput = sortedInput.Prepend(0).Append(sortedInput.Last() +3).ToArray();
            RecursionPartTwo(parsedInput);

            return _resultDictionary.Last().Value.ToString();
        }

        private long RecursionPartTwo(long[] input)
        {
            if (_resultDictionary.ContainsKey(input.Length))
            {
                return _resultDictionary[input.Length];
            }

            if (input.Length == 1)
            {
                return 1;
            }

            long total = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] - input[0] <= 3)
                {
                    total += RecursionPartTwo(input[i..]);
                }
                else
                {
                    break;
                }
            }

            _resultDictionary.Add(input.Length, total);

            return total;
        }
    }
}