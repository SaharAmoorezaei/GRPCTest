using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Grpc.Core;
using System.Linq;
using System.Diagnostics;

namespace Zaraban.Client
{
    class Program
    {
        //static async Task Main(string[] args)
        //{
        //    string command;
        //    using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
        //    {
        //        do
        //        {
        //            Console.WriteLine("Please enter command:(Hello, Ping, Bye)");
        //            command = Console.ReadLine();

        //            var client = new ZarabanChat.ZarabanChatClient(channel);
        //            var response = new ResponseMessage();
        //            var request = new RequestMessage() { Command = command };
        //            switch (command.ToLower())
        //            {
        //                case "hello":
        //                    response = await client.HiAsync(request);
        //                    break;
        //                case "bye":
        //                    response = await client.ByeAsync(request);
        //                    break;
        //                case "ping":
        //                    response = await client.PingAsync(request);
        //                    break;
        //                default:
        //                    response = new ResponseMessage() { Message = "Command is not valid."};
        //                    break;
        //            }

        //            Console.WriteLine($"Server response:{response.Message}");

        //        } while (command.ToLower() != "bye");
        //    }
        //}

        static async Task Main(string[] args)
        {
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {

                var client = new ZarabanChat.ZarabanChatClient(channel);
                //Console.Write("Send Hello:");
                //(await client.SendAsync(new RequestMessage() { Command = "Hello" })).Print();
                //Console.Write("Send Ping:");
                //(await client.SendAsync(new RequestMessage() { Command = "Ping" })).Print();
                //Console.Write("Send incorrect:");
                //(await client.SendAsync(new RequestMessage() { Command = "excpetion" })).Print();
                //Console.Write("Send Bye:");
                //(await client.SendAsync(new RequestMessage() { Command = "Bye" })).Print();

                var tasks = new List<AsyncUnaryCall<ResponseMessage>>();
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "Hello" }));
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "Ping" }));
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "Hello" })); 
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "Ping" }));
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "Hello" }));
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "exception" }));
                tasks.Add(client.SendAsync(new RequestMessage() { Command = "Bye" }));
                var headerTask = tasks.Select(c => c.ResponseHeadersAsync);
                await Task.WhenAny(headerTask);


                foreach (var task in headerTask)
                {
                    
                    if (task.IsCompleted)
                    {
                        var t = task.ToString();
                    }

                }

                Console.ReadLine();


            }
        }
    }
}
