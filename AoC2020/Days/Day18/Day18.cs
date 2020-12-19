using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day18
{
    public class Day18 : BaseDay
    {
        private readonly Stack<Operation> _ops = new();
        public override string SolvePartOne()
        {
            var total = 0L;
            foreach (var line in Input)
            {
                _ops.Push(new Operation());

                foreach (var chr in line.Replace(" ", ""))
                {
                    switch (chr)
                    {
                        case '+':
                            _ops.Peek().Operators.Add('+');
                            break;
                        case '-':
                            _ops.Peek().Operators.Add('-');
                            break;
                        case '*':
                            _ops.Peek().Operators.Add('*');
                            break;
                        case '(':
                            _ops.Push(new Operation());
                            break;
                        case ')':
                            var res = _ops.Pop().CalcPartOne();
                            _ops.Peek().Nums.Add(res);
                            break;
                        default:
                            _ops.Peek().Nums.Add(long.Parse(chr.ToString()));
                            break;
                    }
                }

                total += _ops.Pop().CalcPartOne();
            }

            return total.ToString();
        }

        public override string SolvePartTwo()
        {
            var total = 0L;
            foreach (var line in Input)
            {
                _ops.Push(new Operation());

                foreach (var chr in line.Replace(" ", ""))
                {
                    switch (chr)
                    {
                        case '+':
                            _ops.Peek().Operators.Add('+');
                            break;
                        case '-':
                            _ops.Peek().Operators.Add('-');
                            break;
                        case '*':
                            _ops.Peek().Operators.Add('*');
                            break;
                        case '(':
                            _ops.Push(new Operation());
                            break;
                        case ')':
                            var res = _ops.Pop().CalcPartTwo();
                            _ops.Peek().Nums.Add(res);
                            break;
                        default:
                            _ops.Peek().Nums.Add(long.Parse(chr.ToString()));
                            break;
                    }
                }

                total += _ops.Pop().CalcPartTwo();
            }

            return total.ToString();
        }

        private class Operation
        {
            public readonly List<long> Nums = new();
            public readonly List<char> Operators = new(){'+'};

            public long CalcPartOne()
            {
                var total = 0L;
                for (int i = 0; i < Nums.Count; i++)
                {
                    if (Operators[i] == '+')
                        total += Nums[i];
                    else
                        total *= Nums[i];
                }

                return total;
            }

            public long CalcPartTwo()
            {
                var addition = 0L;
                var allAdditions = new List<long>();
                for (int i = 0; i < Nums.Count; i++)
                {
                    if (Operators[i] == '+')
                        addition += Nums[i];
                    else
                    {
                        allAdditions.Add(addition);
                        addition = Nums[i];
                    }
                }
                
                return allAdditions.Aggregate(addition, (acc, num) => acc * num);
            }
        }
    }
}
