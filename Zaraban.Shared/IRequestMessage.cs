

using System.Runtime.Serialization;
using System.ServiceModel;

namespace Zaraban.Shared
{ 

    public interface IRequestMessage
    {
        string Message { get; set; }
    }

    [DataContract]
    public class RequestMessage : IRequestMessage
    {
        [DataMember(Order = 1, Name = "message")]
        public string Message { get; set; }

        public static implicit operator RequestMessage(string message) =>
            new RequestMessage { Message = message};
    }

    public interface IResponseMessage
    {
        string Message { get; set; }
        bool Success { get; set; }
    }

    [DataContract]
    public class ResponseMessage : IResponseMessage
    {
        [DataMember(Order = 1, Name = "message")]
        public string Message { get; set; }
        [DataMember(Order = 2, Name = "success")]
        public bool Success { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }


    [DataContract]
    public class TResponseMessage : IResponseMessage
    {
        public string Message { get; set; }
        public bool Terminate { get; set; }
        public bool Success { get; set; }
    }
}
