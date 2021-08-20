

using System;

namespace Zaraban.Client
{
    public static class Extentions
    {
        public static void Print(this ResponseMessage responseMessage) {
            if (!responseMessage.Success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(responseMessage.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
