using demo_grpc_svc;
using Grpc.Core;
using gRPCClient;

namespace demo_grpc_svc.Services
{
    public class NotificationService : Notification.NotificationBase
    {
        private readonly ILogger<NotificationService> _logger;
        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public override Task<MessageReplyDetails> SendMessage(MessageRequestDetails request, ServerCallContext context)
        {
            MessageReplyDetails msgRep = new MessageReplyDetails();

            foreach(MessageRequestObject reqObj in request.MsgReqObjects)
            {
                MessageReplyObject repObj = new MessageReplyObject();
                repObj.Id = "RSP-ID-" + reqObj.Id;
                repObj.Message = "RSP-ID-" + reqObj.Message;
                repObj.MessageExp = "RSP-ID-" + reqObj.MessageExp;
                repObj.MessageId = "RSP-ID-" + reqObj.MessageId;
                repObj.MessagePub = "RSP-ID-" + reqObj.MessagePub;
                repObj.MessageType = "RSP-ID-" + reqObj.MessageType;

                msgRep.MsgRepObjects.Add(repObj);
            }

            return Task.FromResult(msgRep);
        }
    }
}