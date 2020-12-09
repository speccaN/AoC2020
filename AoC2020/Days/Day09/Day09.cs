using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day09
{
    public class Day09 : BaseDay
    {
        public override string SolvePartOne()
        {
            var parsedInput = Input.Select(long.Parse).ToArray();
            const int preambleSize = 25;

            var sets = parsedInput
                .Skip(preambleSize)
                .Select((x, i) => (x, nums: parsedInput.Skip(i).Take(preambleSize).ToList()));
            var hs = new HashSet<long>();
            foreach (var (val, nums) in sets)
            {
                var found = false;
                for (int j = 0; j < nums.Count; j++)
                {
                    for (int i = j + 1; i < nums.Count; i++)
                    {
                        if (nums[j] + nums[i] == val)
                        {
                            hs.Add(val);
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }

                if (!hs.Contains(val))
                    return val.ToString();
            }

            return "";
        }

        public override string SolvePartTwo()
        {
            var parsedInput = Input.Select(long.Parse).ToArray();
            const int target = 22406676;

            var currentIndex = 0;
            var takeSize = 1;
            var total = 0L;

            while (true)
            {
                total += parsedInput[currentIndex + takeSize++ - 1];
                switch (total)
                {
                    case target:
                    {
                        var processedNumbers = parsedInput.Skip(currentIndex).Take(takeSize - 1).ToArray();
                        return (processedNumbers.Max() + processedNumbers.Min()).ToString();
                    }
                    case <= target:
                        continue;
                }

                currentIndex++;
                takeSize = 1;
                total = 0;
            }
        }
    }
}