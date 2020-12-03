namespace AoC2020.Days
{
    public abstract class BaseDay<T>
    {
        public virtual T Input { get; private set; }
        protected void SetInput(T val) => Input = val;

        public abstract string SolvePartOne();
        public abstract string SolvePartTwo();
    }
}