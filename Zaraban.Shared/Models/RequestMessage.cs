

namespace Zaraban.Shared.Models
{
    public interface IRequestMessage
    {
        public string Message { get; set; }
    }


    public class RequestMessage : IRequestMessage
    {
        public string Message { get; set; }
    }
}
