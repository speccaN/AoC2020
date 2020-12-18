using AoC2020.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day17
{
    public class Day17 : BaseDay
    {
        public override string SolvePartOne()
        {
            var cube = new Dictionary<(int x, int y, int z), int>(1024);
            int _x = 0, _y = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                foreach (var c in Input[i])
                {
                    cube[(_x++, _y, 0)] = c == '#' ? 1 : 0;
                }
                _x = 0;
                _y++;
            }

            var range = Enumerable.Range(-1, 3);
            var nextCube = new Dictionary<(int x, int y, int z), int>(1024);
            var directions = range
                .SelectMany(x => range
                    .SelectMany(y => range
                        .Select(z => (x, y, z))))
                .Where(w => w != (0, 0, 0))
                .ToArray();

            for (int i = 0; i < 6; i++)
            {
                nextCube.Clear();

                foreach (var key in cube.Keys)
                    nextCube[key] = 0;

                foreach (var ((x, y, z), active) in cube.Where(w => w.Value == 1))
                {
                    foreach (var (dX, dY, dZ) in directions)
                    {
                        nextCube[(dX + x, dY + y, dZ + z)] =
                            nextCube.TryGetValue((dX + x, dY + y, dZ + z), out var hit) ? hit + 1 : 1;
                    }
                }

                foreach (var (coords, hits) in nextCube)
                {
                    cube[coords] = (cube.TryGetValue(coords, out var val) ? val : 0, hits) switch
                    {
                        (1, >= 2 and <= 3) => 1,
                        (0, 3) => 1,
                        _ => 0
                    };
                }
            }

            return cube.Values.Where(w => w == 1).Count().ToString();
        }

        public override string SolvePartTwo()
        {
            var cube = new Dictionary<(int x, int y, int z, int w), int>(8192);
            int _x = 0, _y = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                foreach (var c in Input[i])
                {
                    cube[(_x++, _y, 0, 0)] = c == '#' ? 1 : 0;
                }
                _x = 0;
                _y++;
            }

            var range = Enumerable.Range(-1, 3);
            var nextCube = new Dictionary<(int x, int y, int z, int w), int>(8192);
            var directions = range
                .SelectMany(x => range
                    .SelectMany(y => range
                        .SelectMany(z => range
                        .Select(w => (x,y,z,w)))))
                .Where(w => w != (0, 0, 0, 0))
                .ToArray();

            for (int i = 0; i < 6; i++)
            {
                nextCube.Clear();

                foreach (var key in cube.Keys)
                    nextCube[key] = 0;

                foreach (var ((x, y, z, w), active) in cube.Where(w => w.Value == 1))
                {
                    foreach (var (dX, dY, dZ, dW) in directions)
                    {
                        nextCube[(dX + x, dY + y, dZ + z, dW + w)] =
                            nextCube.TryGetValue((dX + x, dY + y, dZ + z, dW + w), out var hit) ? hit + 1 : 1;
                    }
                }

                foreach (var (coords, hits) in nextCube)
                {
                    cube[coords] = (cube.TryGetValue(coords, out var val) ? val : 0, hits) switch
                    {
                        (1, >= 2 and <= 3) => 1,
                        (0, 3) => 1,
                        _ => 0
                    };
                }
            }

            return cube.Values.Where(w => w == 1).Count().ToString();
        }
    }
}
