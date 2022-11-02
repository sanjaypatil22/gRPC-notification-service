using Microsoft.AspNetCore.Mvc;

namespace RESTful_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "message")]
        public ActionResult<MessageReplyDetails>  Post(MessageRequestDetails req)
        {
            MessageReplyDetails response = new MessageReplyDetails();

            response.MsgReplyObjects = new MessageReplyObject[req.MsgRequestObjects.Length];
            var ind = 0;

            foreach (MessageRequestObject reqObj in req.MsgRequestObjects)
            {
                MessageReplyObject repObj = new MessageReplyObject();
                repObj.Id = "RSP-ID-" + reqObj.Id;
                repObj.Message = "RSP-" + reqObj.Message;
                repObj.MessageExp = "RSP-" + reqObj.MessageExp;
                repObj.MessageId = "RSP-" + reqObj.MessageId;
                repObj.MessagePub = "RSP-" + reqObj.MessagePub;
                repObj.MessageType = "RSP-" + reqObj.MessageType;

                response.MsgReplyObjects[ind++] = repObj;
            }

            return response;
            }
        }
    }