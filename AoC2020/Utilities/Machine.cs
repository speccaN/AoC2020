using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Utilities
{
    public class Machine
    {
        public List<Instruction> ProcessInstructions() =>
            _originalInput.Select(s => new Instruction(s.Split(" ")[0], int.Parse(s.Split(" ")[1]))).ToList();

        public record Instruction(string Operation, int Value);

        private record State(int Accumulator, int IndexPointer);
        private readonly string[] _originalInput;

        public Machine(string[] input)
        {
            _originalInput = input;
        }

        private static State ExecuteInstruction(State state, Instruction instruction) =>
            instruction switch
            {
                { Operation: "acc" } => state with { IndexPointer = state.IndexPointer + 1, Accumulator = state.Accumulator + instruction.Value },
                { Operation: "jmp" } => state with { IndexPointer = state.IndexPointer + instruction.Value },
                { Operation: "nop" } => state with { IndexPointer = state.IndexPointer + +1},
                _ => throw new NotImplementedException("Operation not found")
            };

        public bool RunToCompletion(List<Instruction> program, out int accumulator)
        {
            var visitedIndices = new HashSet<int>();
            var state = new State(0, 0);
            while (!visitedIndices.Contains(state.IndexPointer))
            {
                accumulator = state.Accumulator;
                if (state.IndexPointer == program.Count)
                    return true;
                if (state.IndexPointer > program.Count)
                    return false;

                visitedIndices.Add(state.IndexPointer);
                state = ExecuteInstruction(state, program[state.IndexPointer]);
            }

            accumulator = state.Accumulator;
            return false;
        }

        public IEnumerable<List<Instruction>> GetAllPossiblePrograms(List<Instruction> program)
        {
            foreach (var (instruction, i) in program.Select((op, i) => (op, i)))
            {
                switch (instruction.Operation)
                {
                    case "nop":
                    {
                        var newProgram = new List<Instruction>(program) { [i] = instruction with { Operation = "jmp" } };
                        yield return newProgram;
                        break;
                    }
                    case "jmp":
                    {
                        var newProgram = new List<Instruction>(program) { [i] = instruction with { Operation = "nop" } };
                        yield return newProgram;
                        break;
                    }
                }
            }
        }
    }
}