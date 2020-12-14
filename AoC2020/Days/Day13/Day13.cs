using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day13
{
    public class Day13 : BaseDay
    {
        public override string SolvePartOne()
        {
            var timestamp = int.Parse(Input[0]);
            var timestamps = new Dictionary<int,int>();
            var busNumbers = Input[1].Split(",").Where(w => char.IsDigit(w[0])).Select(int.Parse).ToArray();

            for (int i = 0; i < busNumbers.Length; i++)
            {
                var nextTimestamp = timestamp;
                while (++nextTimestamp % busNumbers[i] != 0)
                {
                }

                timestamps.Add(busNumbers[i], nextTimestamp);
            }

            var min = timestamps.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
            var waitTime = (timestamps[min] - timestamp) * min;

            return waitTime.ToString();
        }

        public override string SolvePartTwo()
        {
            var arr = Input[1].Split(",");
            var time = 0L;
            var num = long.Parse(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == "x") continue;

                var nextTime = int.Parse(arr[i]);
                while (true)
                {
                    time += num;
                    if ((time + i) % nextTime == 0)
                    {
                        num *= nextTime;
                        break;
                    }
                }
            }

            return time.ToString();
        }
    }
}