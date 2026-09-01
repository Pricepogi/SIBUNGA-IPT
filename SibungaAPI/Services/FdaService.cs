using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using SibungaAPI.Models;

namespace SibungaAPI.Services
{
    public class FdaService
    {
        private readonly IHttpClientFactory _factory;

        public FdaService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<FdaResponse?> GetFoodEnforcementAsync(int limit = 10, CancellationToken ct = default)
        {
            try
            {
                var client = _factory.CreateClient("fda");
                var url = $"food/enforcement.json?limit={limit}";
                var res = await client.GetAsync(url, ct);
                if (!res.IsSuccessStatusCode) return null;
                var doc = await JsonSerializer.DeserializeAsync<FdaResponse>(await res.Content.ReadAsStreamAsync(ct), cancellationToken: ct);
                return doc;
            }
            catch
            {
                return null;
            }
        }
    }
}
