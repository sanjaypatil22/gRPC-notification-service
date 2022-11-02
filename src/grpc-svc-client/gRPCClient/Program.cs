using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPCClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress($"http://localhost:8085");

var client = new Notification.NotificationClient(channel);

Console.WriteLine("Press any key to continue...");
Console.ReadKey();

int[] objSize = new int[] { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000,
                            1050, 1100, 1150, 1200, 1250, 1300, 1350, 1400, 1450, 1500, 1550, 1600, 1650, 1700, 1750, 1800, 1850, 1900};

Console.WriteLine("\t\t" + "Message Count" + "\t\t" + "Response Time (ms)" + "\t" + "Response Size (kb)");

foreach (int testObjSize in objSize)
{
    MessageRequestDetails msgReq = new MessageRequestDetails();

    for (int i = 0; i < testObjSize; i++)
    {
        MessageRequestObject reqObj = new MessageRequestObject();
        reqObj.Id = "102" + i.ToString();
        reqObj.Message = "TestMessage";
        reqObj.MessageExp = "TestMessageExp";
        reqObj.MessageId = "TestMessageId";
        reqObj.MessagePub = "TestMessagePub";
        reqObj.MessageType = "TestMessageType";

        msgReq.MsgReqObjects.Add(reqObj);
    }

    var startTime = DateTime.Now;

    var reply = await client.SendMessageAsync(msgReq);

    var endTime = DateTime.Now;

    Console.WriteLine("\t\t" + testObjSize.ToString() + "\t\t\t" + (endTime - startTime).TotalMilliseconds + "\t\t\t" + (reply.CalculateSize()/1024).ToString());
}