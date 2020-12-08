using AoC2020.Utilities;

namespace AoC2020.Days.Day08
{
    public class Day08 : BaseDay
    {
        private readonly Machine _machine;

        public Day08()
        {
            _machine = new Machine(Input);
        }

        public override string SolvePartOne()
        {
            _machine.RunToCompletion(_machine.ProcessInstructions(), out var accumulator);
            return accumulator.ToString();
        }

        public override string SolvePartTwo()
        {
            foreach (var program in _machine.GetAllPossiblePrograms(_machine.ProcessInstructions()))
            {
                if (_machine.RunToCompletion(program, out var accumulator))
                    return accumulator.ToString();
            }

            return "";
        }
    }
}