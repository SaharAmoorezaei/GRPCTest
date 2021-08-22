using System;
using System.Threading.Tasks;
using Zaraban.Shared.Models;

namespace Zaraban.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string command;
            var client = new Client("https://localhost:5001");
            do
            {
                Console.WriteLine("Please enter command:(Hello, Ping, Bye)");
                command = Console.ReadLine();
                var requestMessage = new RequestMessage() { Message = command };
                var response = await client.SendAsync<ConsoleResponseMessage>(requestMessage);
                response.Print();
            } while (command.ToLower() != "bye");

            Console.ReadLine();
        }
    }
}
