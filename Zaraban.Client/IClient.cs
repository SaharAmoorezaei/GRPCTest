
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading.Tasks;
using Zaraban.Shared;

namespace Zaraban.Client
{
    public interface IClient
    {
        Task<IResponseMessage> SendAsync(RequestMessage requestMessage);
    }


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
        public async Task<IResponseMessage> SendAsync(RequestMessage requestMessage)
        {
            return await _client.SendAsync(requestMessage);
        }

        public async Task SendWithLogAsync(RequestMessage requestMessage)
        {
            Console.WriteLine(requestMessage.Message  + " Sent at: " + DateTime.Now);
            var result =  await _client.SendAsync(requestMessage);
            Console.WriteLine(requestMessage.Message + " get response "+ result.Message+" at: " + DateTime.Now);
        }

        public IResponseMessage Send(RequestMessage requestMessage)
        {
            return _client.SendAsync(requestMessage).Result;
        }

        public async Task CloseConnection()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _channel.Dispose();
        }
    }
}
