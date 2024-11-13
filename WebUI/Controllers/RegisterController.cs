using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.UserDtos;

namespace WebUI.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly HttpClient _httpClient;

        public RegisterController(IConfiguration configuration, IHttpClientFactory httpClient) : base(configuration)
        {
            _httpClient = httpClient.CreateClient("API");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterDto dto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("Account/register", dto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Redirect("/home/error");
        }


        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            return View();
        }
    }
}
