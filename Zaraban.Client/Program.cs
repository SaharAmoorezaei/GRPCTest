using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using ProtoBuf.Grpc.Client;
using Zaraban.Shared;
using System.Threading;

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

        //static async Task Main(string[] args)
        //{
        //    using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
        //    {

        //        var client = new ZarabanChat.ZarabanChatClient(channel);
        //        //Console.Write("Send Hello:");
        //        //(await client.SendAsync(new RequestMessage() { Command = "Hello" })).Print();
        //        //Console.Write("Send Ping:");
        //        //(await client.SendAsync(new RequestMessage() { Command = "Ping" })).Print();
        //        //Console.Write("Send incorrect:");
        //        //(await client.SendAsync(new RequestMessage() { Command = "excpetion" })).Print();
        //        //Console.Write("Send Bye:");
        //        //(await client.SendAsync(new RequestMessage() { Command = "Bye" })).Print();

        //        var tasks = new List<AsyncUnaryCall<ResponseMessage>>();
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "Hello" }));
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "Ping" }));
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "Hello" })); 
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "Ping" }));
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "Hello" }));
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "exception" }));
        //        tasks.Add(client.SendAsync(new RequestMessage() { Command = "Bye" }));
        //        var headerTask = tasks.Select(c => c.ResponseHeadersAsync);
        //        await Task.WhenAny(headerTask);


        //        foreach (var task in headerTask)
        //        {

        //            if (task.IsCompleted)
        //            {
        //                var t = task.ToString();
        //            }

        //        }

        //        Console.ReadLine();


        //    }
        //}


        static async Task Main(string[] args)
        {
            //using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            //{
            //    GrpcClientFactory.AllowUnencryptedHttp2 = true;
            //    var client = channel.CreateGrpcService<IChatService>();
            //    var result2 = await client.SendAsync(new RequestMessage() { Message = "Hello" });
            //    //var result = await client.SendAsync("Hello");
            //    result2.Success = true;
            //    Console.WriteLine(result2.Message);
            //    //Console.WriteLine(result);
            //    Console.ReadLine();
            //}
            //Console.ReadLine();
            
            Thread t1 = new Thread(() =>
            {
                var client = new Client("https://localhost:5001");
                client.SendWithLogAsync("hello").Wait();
            });
            t1.Start();

            var t2 = new Thread(() =>
            {
                var client = new Client("https://localhost:5001");
                client.SendWithLogAsync("ping").Wait();
            });
            t2.Start();

            t2.Join();
            Console.WriteLine("finish");
            Console.ReadLine();
        }
    }
}
