using System.Text.Json.Serialization;

namespace SmsPortal.net.Responses
{
    internal class BalanceResponse
    {
        [JsonPropertyName("balance")]
        public double Balance { get; set; }
    }
}
