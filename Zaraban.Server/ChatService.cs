
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Zaraban.Shared;

namespace Zaraban.Server.Services
{
    public class ChatService : IChatService
    {
        private readonly ILogger<ChatService> _logger;

        public ChatService(ILogger<ChatService> logger)
        {
            _logger = logger;
        }
        public Task<ResponseMessage> SendAsync(RequestMessage message)
        {
            _logger.LogWarning($"Send({message.Message}) at { DateTime.Now.ToString("mm:ss:ms") }");
            switch (message.Message.ToLower())
            {
                case "hello":
                    return Hi();

                case "ping":
                    return Ping();

                case "bye":
                    return Bye();

                default:
                    return Exception();
            }

        }

        private Task<ResponseMessage> Hi()
        {
            Task.Delay(10000);
            return Task.FromResult(new ResponseMessage
            {
                Message = "Hi",
                Success = true
            });
        }

        private Task<ResponseMessage> Ping()
        {
            return Task.FromResult(new ResponseMessage
            {
                Message = "Pong",
                Success = true
            });
        }

        private Task<ResponseMessage> Bye()
        {
            return Task.FromResult(new ResponseMessage
            {
                Message = "Bye",
                Success = true
            });
        }

        private Task<ResponseMessage> Exception()
        {
            return Task.FromResult(new ResponseMessage
            {
                Message = "Invalid message",
                Success = true
            });
        }
    }
}
