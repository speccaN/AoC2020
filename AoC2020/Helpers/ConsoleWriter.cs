using System;

namespace AoC2020.Helpers
{
    public static class ConsoleWriter
    {
        public static void PrintDayToConsole(string day)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(day);
        }

        public static void PrintProblemSeparator() => Console.WriteLine("-----------");
        public static void PrintDaySeparator() => Console.WriteLine("=========================================");

        public static void PrintToConsole(string method, string val)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(method);
            Console.ResetColor();
            Console.WriteLine(val);
        }
    }
}