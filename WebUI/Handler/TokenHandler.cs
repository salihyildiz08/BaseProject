using System.Net.Http.Headers;

namespace WebUI.Handler
{
    public class TokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TokenHandler> _logger;

        public TokenHandler(IHttpContextAccessor httpContextAccessor, ILogger<TokenHandler> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Cookie'den token'ı alıyoruz
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["AuthToken"];

            if (!string.IsNullOrEmpty(token))
            {
                // Authorization header'a token'ı ekliyoruz
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                _logger.LogInformation("Token başarıyla eklendi: {Token}", token);  // Token log'lama
            }
            else
            {
                _logger.LogWarning("Token bulunamadı.");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
