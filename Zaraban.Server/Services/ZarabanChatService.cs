
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Zaraban.Server.Services
{
    public class ZarabanChatService : ZarabanChat.ZarabanChatBase
    {
        private readonly ILogger<ZarabanChatService> _logger;
        public ZarabanChatService(ILogger<ZarabanChatService> logger)
        {
            _logger = logger;
        }


        public override Task<ResponseMessage> Send(RequestMessage request, ServerCallContext context)
        {
            switch(request.Command.ToLower())
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
                Message = "Invalid command.",
                Success = false
            }); ;
        }
    }
}
