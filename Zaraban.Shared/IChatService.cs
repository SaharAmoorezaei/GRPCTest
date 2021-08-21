

using System.ServiceModel;
using System.Threading.Tasks;

namespace Zaraban.Shared
{
    [ServiceContract(Name = "Zaraban.Client")]
    public interface IChatService
    {
        //Task<string> SendAsync(string message);
        Task<ResponseMessage> SendAsync(RequestMessage message);
        //Task<TResponseMessage> SendAsync<TResponseMessage>(IRequestMessage message) where TResponseMessage : IResponseMessage;
    }
}
