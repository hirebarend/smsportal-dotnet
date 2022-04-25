using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmsPortal.net.Models
{
    internal class LandingPageVariables
    {
        [JsonPropertyName("landingPageId")]
        public string LandingPageId { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("variables")]
        public IDictionary<string, string> Variables { get; set; }

        [JsonPropertyName("version")]
        public uint Version { get; set; }
    }
}
