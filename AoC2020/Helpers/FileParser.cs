using System;
using System.IO;
using System.Linq;

namespace AoC2020.Helpers
{
    public static class FileParser
    {
        public static int[] ReadFromFile(string day) => File
            .ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Days", day, $"{day}.txt"))
            .Select(int.Parse).ToArray();
    }
}