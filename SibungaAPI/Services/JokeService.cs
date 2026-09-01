using System.Net.Http;
using System.Net.Http.Json;
using SibungaAPI.Models;

namespace SibungaAPI.Services
{
    public class JokeService
    {
        private readonly IHttpClientFactory _factory;

        public JokeService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<Joke?> GetRandomJokeAsync(CancellationToken ct = default)
        {
            try
            {
                var client = _factory.CreateClient("joke");
                var j = await client.GetFromJsonAsync<Joke>("random_joke", ct);
                return j;
            }
            catch
            {
                return null;
            }
        }
    }
}
