
using System.Threading.Tasks;
using Zaraban.Shared;

namespace Zaraban.Server.Services
{
    public class Client : IClient
    {

        public Task<IResponseMessage> SendAsync(IRequestMessage message)
        {
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

        public Task<string> SendAsync(string message)
        {
            switch (message.ToLower())
            {
                case "hello":
                    return Task.FromResult("Hi");

                case "ping":
                    return Task.FromResult("Pong");

                case "bye":
                    return Task.FromResult("Bye");

                default:
                    return Task.FromResult("Invalid Message.");
            }
        }

        private Task<IResponseMessage> Hi()
        {
            Task.Delay(10000);
            return Task.FromResult<IResponseMessage>(new Shared.ResponseMessage
            {
                Message = "Pong",
                Success = true
            });
        }

        private Task<IResponseMessage> Ping()
        {
            return Task.FromResult<IResponseMessage>(new Shared.ResponseMessage
            {
                Message = "Pong",
                Success = true
            });
        }

        private Task<IResponseMessage> Bye()
        {
            return Task.FromResult<IResponseMessage>(new Shared.ResponseMessage
            {
                Message = "Bye",
                Success = true
            });
        }

        private Task<IResponseMessage> Exception()
        {
            return Task.FromResult<IResponseMessage>(new Shared.ResponseMessage
            {
                Message = "Invalid message",
                Success = true
            });
        }
    }
}
