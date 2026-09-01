using System.Text.Json.Serialization;

namespace SibungaAPI.Models
{
    public class FdaResponse
    {
        [JsonPropertyName("meta")]
        public object? Meta { get; set; }

        [JsonPropertyName("results")]
        public List<FdaResult>? Results { get; set; }
    }

    public class FdaResult
    {
        [JsonPropertyName("recall_number")]
        public string? RecallNumber { get; set; }

        [JsonPropertyName("product_description")]
        public string? ProductDescription { get; set; }

        [JsonPropertyName("reason_for_recall")]
        public string? ReasonForRecall { get; set; }

        [JsonPropertyName("distribution_pattern")]
        public string? DistributionPattern { get; set; }

        [JsonPropertyName("recall_initiation_date")]
        public string? RecallInitiationDate { get; set; }
    }
}
