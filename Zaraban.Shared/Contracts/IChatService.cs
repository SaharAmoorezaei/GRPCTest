
using System.ServiceModel;
using System.Threading.Tasks;

namespace Zaraban.Shared.Contracts
{
    [ServiceContract(Name = "Zaraban.ChatService")]
    public interface IChatService
    {
        [OperationContract]
        Task<string> SendAsync(string message);
    }
}
