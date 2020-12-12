using System.Linq;

namespace AoC2020.Days.Day11
{
    public class Day11 : BaseDay
    {
        private const int FREE = 0;
        private const int OCCUPIED = 1;
        private const int FLOOR = -1;
        
        private int[,] _grid;

        public override string SolvePartOne()
        {
            _grid = ParseGrid(Input);
            while (Run(ray: false, maxHits: 4)) { }
            return Enumerable.Range(0, _grid.GetUpperBound(0) + 1).SelectMany(x => Enumerable
                .Range(0, _grid.GetUpperBound(1) + 1).Select(y => _grid[x, y])).Count(w => w.Equals(OCCUPIED)).ToString();
        }

        public override string SolvePartTwo()
        {
            _grid = ParseGrid(Input);
            while (Run(ray: true, maxHits: 5)) { }
            return Enumerable.Range(0, _grid.GetUpperBound(0) + 1).SelectMany(x => Enumerable
                .Range(0, _grid.GetUpperBound(1) + 1).Select(y => _grid[x, y])).Count(w => w.Equals(OCCUPIED)).ToString();
        }

        public bool Run(bool ray, int maxHits)
        {
            var row = _grid.GetUpperBound(0) + 1;
            var col = _grid.GetUpperBound(1) + 1;
            var newGrid = new int[row, col];
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    newGrid[x, y] = PredictLineOfSight(x, y, ray, maxHits);
                }
            }
            if (Equal(_grid, newGrid))
                return false;
            _grid = newGrid;
            return true;
        }

        private int PredictLineOfSight(int x, int y, bool ray, int maxHits)
        {
            var result = _grid[x, y];
            var occupied = TraverseGridAndCountOccupied(x, y, ray);
            if (occupied == FREE)
                return OCCUPIED;
            return occupied >= maxHits ? 0 : result;
        }

        private int TraverseGridAndCountOccupied(int currentX, int currentY, bool ray)
        {
            int occupied = 0;
            if (_grid[currentX, currentY] == FLOOR) return 1;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue;
                    var o = Peek(currentX + x, currentY + y, x, y, ray);
                    occupied += o > 0 ? o : 0;
                }
            }
            return occupied;
        }

        private int Peek(int lookAtX, int lookAtY, int x, int y, bool ray)
        {
            while (true)
            {
                if (lookAtX < 0 || lookAtX > _grid.GetUpperBound(0) || lookAtY < 0 || lookAtY > _grid.GetUpperBound(1)) return 0;
                if (_grid[lookAtX, lookAtY] < 0 && ray)
                {
                    lookAtX += x;
                    lookAtY += y;
                }
                else
                    return _grid[lookAtX, lookAtY];
            }
        }

        private bool Equal(int[,] grid, int[,] newGrid)
        {
            var (boundX, boundY) = (grid.GetUpperBound(0) + 1, grid.GetUpperBound(1) + 1);
            for (int x = 0; x < boundX; x++)
            {
                for (int y = 0; y < boundY; y++)
                    if (grid[x, y] != newGrid[x, y]) return false;
            }
            return true;
        }

        private int[,] ParseGrid(string[] input)
        {
            input = input.Select(s => s.Replace("L", "#")).ToArray();
            _grid = new int[input.Length, input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    _grid[i, j] = input[i][j] switch
                    {
                        '#' => OCCUPIED,
                        '.' => FLOOR,
                        _ => _grid[i, j]
                    };
                }
            }

            return _grid;
        }
    }
}