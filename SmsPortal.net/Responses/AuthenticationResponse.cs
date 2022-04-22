using System.Text.Json.Serialization;

namespace SmsPortal.net.Responses
{
    internal class AuthenticationResponse
    {
        [JsonPropertyName("expiresInMinutes")]
        public uint ExpiresInMinutes { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("schema")]
        public string Schema { get; set; }
    }
}
