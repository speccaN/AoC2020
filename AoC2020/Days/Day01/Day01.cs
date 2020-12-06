using System.Linq;

namespace AoC2020.Days.Day01
{
    public sealed class Day01 : BaseDay
    {
        int[] _input { get; }

        public Day01()
        {
            _input = Input.Select(int.Parse).ToArray();
        }

        public override string SolvePartOne()
        {
            var result = 0;
            for (int i = 0; i < _input.Length; i++)
                for (int j = i + 1; j < _input.Length; j++)
                    if (_input[i] + _input[j] == 2020)
                        result = _input[i] * _input[j];

            return result.ToString();
        }

        public override string SolvePartTwo()
        {
            var result = 0;
            for (int i = 0; i < _input.Length; i++)
                for (int j = i + 1; j < _input.Length; j++)
                    for (int k = j + 1; k < _input.Length; k++)
                        if (_input[i] + _input[j] + _input[k] == 2020)
                            result = _input[i] * _input[j] * _input[k];

            return result.ToString();
        }

        public string SolvePartOne_Linq() => _input.Where(w => _input.Contains(2020 - w)).Aggregate(1, (a, b) => a * b).ToString();

        public string SolvePartTwo_Linq() => _input.Where(w => 0 < _input.FirstOrDefault(c => _input.Contains(2020 - w - c))).Aggregate(1, (a, b) => a * b).ToString();

        public string SolvePartTwo_HashSet()
        {
            var hs = _input.ToHashSet();

            return hs.Where(w => 0 < hs.FirstOrDefault(c => hs.Contains(2020 - w - c)))
                .Aggregate(1, (a, b) => a * b).ToString();
        }
    }
}