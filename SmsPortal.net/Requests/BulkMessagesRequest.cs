using SmsPortal.net.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmsPortal.net.Requests
{
    internal class BulkMessagesRequest
    {
        [JsonPropertyName("messages")]
        public IList<Models.Message> Messages { get; set; }

        [JsonPropertyName("sendOptions")]
        public SendOptions? SendOptions { get; set; }
    }
}
