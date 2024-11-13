using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.UserDtos;

namespace WebUI.Controllers
{
    public class UserController : BaseController
    {
        private readonly HttpClient _httpClient;

        public UserController(IConfiguration configuration, IHttpClientFactory httpClient) : base(configuration)
        {
            _httpClient = httpClient.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultUserDto>>($"Account/userlist");
            if (response != null)
            {
                return View(response);
            }

            return Redirect("/home/error");
        }

        public async Task<IActionResult> ChangeMyPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeMyPassword(ChangePasswordDto model)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("Account/changepassword", model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ChangeMyPassword");
            }

            return BadRequest("Şifre değişimi başarısız.");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("Account/changepassword", model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return BadRequest("Şifre değişimi başarısız.");
        }

        



    }
}
