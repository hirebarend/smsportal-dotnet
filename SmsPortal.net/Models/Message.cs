using System.Text.Json.Serialization;

namespace SmsPortal.net.Models
{
    internal class Message
    {
        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("landingPageVariables")]
        public LandingPageVariables? LandingPageVariables { get; set; }

        public static Message Create(string content, string destination)
        {
            return new Message
            {
                Content = content,
                CustomerId = null,
                Destination = destination,
                LandingPageVariables = null,
            };
        }
    }
}
