using CurrencyTable.Interfaces;

namespace CurrencyTable.HttpClients
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _factory;
        private readonly HttpClient _client;

        public HttpClientService(IHttpClientFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        public async Task<string> RequestGet(string uri)
        {
            using (var response = await _client.GetAsync(uri))
            {
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
