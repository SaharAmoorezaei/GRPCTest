

using System.Threading.Tasks;
using Zaraban.Shared.Models;

namespace Zaraban.Shared.Contracts
{
    public interface IClient
    {
        Task<string> SendAsync(string message);
        Task<IResponseMessage> SendAsync(IRequestMessage requestMessage);
        Task CloseConnection();
    }
}
