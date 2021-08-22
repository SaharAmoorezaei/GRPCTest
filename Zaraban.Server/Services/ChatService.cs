
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Zaraban.Shared.Contracts;

namespace Zaraban.Server.Services
{
    public class ChatService : IChatService
    {
        private ILogger<ChatService> Logger { get; set; }
        public ChatService(ILogger<ChatService> logger)
        {
            Logger = logger;
        }
        public Task<string> SendAsync(string message)
        {
            Logger.LogInformation($"{message} Sent at: {DateTime.Now}");
            switch (message.ToLower())
            {
                case "hello":
                    Task.Delay(10000);
                    return Task.FromResult("Hi");

                case "ping":
                    return Task.FromResult("Pong");

                case "bye":
                    return  Task.FromResult("Bye");

                default:
                    return Task.FromResult("Exception");
            }
        }
    }
}
