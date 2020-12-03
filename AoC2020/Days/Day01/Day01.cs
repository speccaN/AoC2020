using System.Linq;
using AoC2020.Helpers;

namespace AoC2020.Days.Day01
{
    public sealed class Day01 : BaseDay<int[]>
    {
        public Day01()
        {
            SetInput(FileParser.ReadFromFile(nameof(Day01)).Select(int.Parse).ToArray());
        }

        public override string SolvePartOne()
        {
            var result = 0;
            for (int i = 0; i < Input.Length; i++)
                for (int j = i + 1; j < Input.Length; j++)
                    if (Input[i] + Input[j] == 2020)
                        result = Input[i] * Input[j];

            return result.ToString();
        }

        public override string SolvePartTwo()
        {
            var result = 0;
            for (int i = 0; i < Input.Length; i++)
                for (int j = i + 1; j < Input.Length; j++)
                    for (int k = j + 1; k < Input.Length; k++)
                        if (Input[i] + Input[j] + Input[k] == 2020)
                            result = Input[i] * Input[j] * Input[k];

            return result.ToString();
        }


        public string SolvePartOne_Linq() => Input.Where(w => Input.Contains(2020-w)).Aggregate(1, (a,b) => a*b).ToString();

        public string SolvePartTwo_Linq() => Input.Where(w => 0 < Input.FirstOrDefault(c => Input.Contains(2020 - w - c))).Aggregate(1, (a, b) => a * b).ToString();

        public string SolvePartTwo_HashSet()
        {
            var hs = Input.ToHashSet();

            return hs.Where(w => 0 < hs.FirstOrDefault(c => hs.Contains(2020 - w - c)))
                .Aggregate(1, (a, b) => a * b).ToString();
        }
    }
}