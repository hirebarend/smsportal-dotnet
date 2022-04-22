using SmsPortal.net.Models;
using System.Text.Json.Serialization;

namespace SmsPortal.net.Requests
{
    internal class BulkMessagesRequest
    {
        [JsonPropertyName("messages")]
        public IList<Message> Messages { get; set; }

        [JsonPropertyName("sendOptions")]
        public SendOptions? SendOptions { get; set; }

        public static BulkMessagesRequest Create(string content, string destination)
        {
            return new BulkMessagesRequest
            {
                Messages = new List<Message>
                {
                    Message.Create(content, destination),
                },
                SendOptions = null,
            };
        }
    }
}
