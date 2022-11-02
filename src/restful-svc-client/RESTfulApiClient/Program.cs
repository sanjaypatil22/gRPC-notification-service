using RESTful_API;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;

HttpClient client = new HttpClient();

client.BaseAddress = new Uri("https://localhost:7080/");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

Console.WriteLine("Press any key to continue...");
Console.ReadKey();

int[] objSize = new int[] { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000,
                            1050, 1100, 1150, 1200, 1250, 1300, 1350, 1400, 1450, 1500, 1550, 1600, 1650, 1700, 1750, 1800, 1850, 1900};

Console.WriteLine("\t\t" + "Message Count" + "\t\t" + "Response Time (ms)" + "\t" + "Response size- (kb)");

foreach (int testObjSize in objSize)
{   { 
        MessageRequestDetails msgReq = new MessageRequestDetails();
        msgReq.MsgRequestObjects = new MessageRequestObject[testObjSize];

        for (int i = 0; i < testObjSize; i++)
        {
            MessageRequestObject reqObj = new MessageRequestObject();
            reqObj.Id = "IDP-MSG-PRG-" + i.ToString();
            reqObj.Message = "TestMessage";
            reqObj.MessageExp = "TestMessageExp";
            reqObj.MessageId = "TestMessageId";
            reqObj.MessagePub = "TestMessagePub";
            reqObj.MessageType = "TestMessageType";

            msgReq.MsgRequestObjects[i] = reqObj;
        }

        var startTime = DateTime.Now;

        HttpResponseMessage response = await client.PostAsJsonAsync(
                        "Notification", msgReq);

        response.EnsureSuccessStatusCode();

        var endTime = DateTime.Now;

        Console.WriteLine("\t\t" + testObjSize.ToString() + "\t\t\t" + (endTime - startTime).TotalMilliseconds + "\t\t\t" + (response.Content.Headers.ContentLength / 1024).ToString());
    }
}

Console.WriteLine("Press any key to exit...");
