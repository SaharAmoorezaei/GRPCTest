using System;
using System.Threading.Tasks;
using Zaraban.Shared.Helper;
using Zaraban.Shared.Models;

namespace Zaraban.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string command;
            IResponseMessage response;
            var client = new Client("https://localhost:5001");
            Console.WriteLine("Please enter command:(Hello, Ping, Bye)");
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                var requestMessage = new RequestMessage() { Message = command };
                response = await client.SendAsync<ConsoleResponseMessage>(requestMessage);
        
                response.Print();
            } while (!response.IsTerminated);
            await client.CloseConnection();
            ConsoleHelper.LogError("Connection closed.Press any key to exit...");
            Console.ReadKey();
        }
    }
}
