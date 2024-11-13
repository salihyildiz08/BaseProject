namespace WebUI.Helper
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public ApiService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _baseUrl = configuration["ApiBaseUrl"];
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent content)
        {
            var url = $"{_baseUrl}/{endpoint}";
            return await _client.PutAsync(url, content);
        }
    }
}
