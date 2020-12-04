using AoC2020.Helpers;

namespace AoC2020.Days
{
    public abstract class BaseDay
    {

        private string[] _input;

        public string[] Input => _input ?? FileParser.ReadFromFile(GetType().Name);

        public abstract string SolvePartOne();
        public abstract string SolvePartTwo();
    }
}