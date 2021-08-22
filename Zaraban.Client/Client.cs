
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading.Tasks;
using Zaraban.Shared.Contracts;
using Zaraban.Shared.Models;

namespace Zaraban.Client
{
    public class Client : IClient, IDisposable
    {
        public string ServerAddress { get; }
        private readonly GrpcChannel _channel;
        private readonly IChatService _client;
        public Client(string serverAddress)
        {
            ServerAddress = serverAddress;
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            _channel = GrpcChannel.ForAddress(ServerAddress);
            _client = _channel.CreateGrpcService<IChatService>();
        }

        public async Task<string> SendAsync(string message)
        {
            return await _client.SendAsync(message);
        }

        public async Task<IResponseMessage> SendAsync(IRequestMessage requestMessage)
        {
            var response = await _client.SendAsync(requestMessage.Message);  
            
            return new ResponseMessage() { Message = response, Success = response != "Exception", IsTerminated = response == "Bye" };
        }

        public async Task<TResponseMessage> SendAsync<TResponseMessage>(IRequestMessage requestMessage) where TResponseMessage : IResponseMessage, new()
        {
            var response = await _client.SendAsync(requestMessage.Message);
            return new TResponseMessage() { Message = response, Success = response != "Exception", IsTerminated = response == "Bye" };
        }


        public async Task CloseConnection()
        {
            await _channel.ShutdownAsync();
        }

        public void Dispose()
        {
            _channel.Dispose();
        }

    }
}
