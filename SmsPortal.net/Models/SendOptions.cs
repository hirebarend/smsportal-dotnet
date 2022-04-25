using System;
using System.Text.Json.Serialization;

namespace SmsPortal.net.Models
{
    internal class SendOptions
    {
        [JsonPropertyName("allowContentTrimming")]
        public bool? AllowContentTrimming { get; set; }

        [JsonPropertyName("campaignName")]
        public string? CampaignName { get; set; }

        [JsonPropertyName("checkOptOuts")]
        public bool? CheckOptOuts { get; set; }

        [JsonPropertyName("costCentre")]
        public string? CostCentre { get; set; }

        [JsonPropertyName("duplicateCheck")]
        public string? DuplicateCheck { get; set; }

        [JsonPropertyName("endDeliveryUtc")]
        public DateTime? EndDeliveryUtc { get; set; }

        [JsonPropertyName("extraForwardEmails")]
        public string? ExtraForwardEmails { get; set; }

        [JsonPropertyName("replyRuleSetName")]
        public string? ReplyRuleSetName { get; set; }

        [JsonPropertyName("replyRuleVersion")]
        public int? ReplyRuleVersion { get; set; }

        [JsonPropertyName("rulename")]
        public string? Rulename { get; set; }

        [JsonPropertyName("shortenUrls")]
        public bool? ShortenUrls { get; set; }

        [JsonPropertyName("senderId")]
        public string? SenderId { get; set; }

        [JsonPropertyName("startDeliveryUtc")]
        public DateTime? StartDeliveryUtc { get; set; }

        [JsonPropertyName("testMode")]
        public bool? TestMode { get; set; }

        [JsonPropertyName("validityPeriod")]
        public int? ValidityPeriod { get; set; }
    }
}
