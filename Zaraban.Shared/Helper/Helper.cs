
using System;

namespace Zaraban.Shared.Helper
{
    public static class ConsoleHelper
    {
        public static void LogError(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void LogWarning(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
