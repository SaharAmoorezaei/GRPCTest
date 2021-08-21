

using System.ServiceModel;
using System.Threading.Tasks;

namespace Zaraban.Shared
{
    [ServiceContract(Name = "Zaraban.Client")]
    public interface IClient
    {
        Task<string> SendAsync(string message);
        Task<IResponseMessage> SendAsync(IRequestMessage message);
        //Task<TResponseMessage> SendAsync<TResponseMessage>(IRequestMessage message) where TResponseMessage : IResponseMessage;
    }
}
