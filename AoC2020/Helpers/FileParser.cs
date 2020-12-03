using System;
using System.IO;

namespace AoC2020.Helpers
{
    public static class FileParser
    {
        public static string[] ReadFromFile(string day) => File
            .ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Days", day, $"{day}.txt"));
    }
}