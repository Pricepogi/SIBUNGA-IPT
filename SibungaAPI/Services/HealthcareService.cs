using System.Net.Http;
using System.Text.Json;
using SibungaAPI.Models;

namespace SibungaAPI.Services
{
    public class HealthcareService
    {
        private readonly IHttpClientFactory _factory;

        public HealthcareService(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        // Use the nationalize.io API: GET ?name={name}
        public async Task<NationalizeResponse?> GetIndexAsync(string name = "bock", CancellationToken ct = default)
        {
            try
            {
                var client = _factory.CreateClient("healthcare");
                var stream = await client.GetStreamAsync($"?name={Uri.EscapeDataString(name)}");
                var doc = await JsonSerializer.DeserializeAsync<NationalizeResponse>(stream, cancellationToken: ct);
                return doc;
            }
            catch
            {
                return null;
            }
        }
    }
}
