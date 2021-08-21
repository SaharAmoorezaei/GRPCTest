

using System.ServiceModel;

namespace Zaraban.Shared
{
    public interface IRequestMessage
    {
        string Message { get; set; }
    }

    [ServiceContract]
    public class RequestMessage : IRequestMessage
    {
        public string Message { get; set; }
    }


    public interface IResponseMessage
    {
        string Message { get; set; }
        bool Success { get; set; }
    }

    [ServiceContract]
    public class ResponseMessage : IResponseMessage
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }


    [ServiceContract]
    public class TResponseMessage : IResponseMessage
    {
        public string Message { get; set; }
        public bool Terminate { get; set; }
        public bool Success { get; set; }
    }
}
