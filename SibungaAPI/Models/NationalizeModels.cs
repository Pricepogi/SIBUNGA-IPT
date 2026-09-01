using System.Text.Json.Serialization;

namespace SibungaAPI.Models
{
    public class NationalizeResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public List<NationalizeCountry>? Country { get; set; }
    }

    public class NationalizeCountry
    {
        [JsonPropertyName("country_id")]
        public string? CountryId { get; set; }

        [JsonPropertyName("probability")]
        public double Probability { get; set; }
    }
}
