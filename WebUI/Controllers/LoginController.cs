using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.UserDtos;
using WebUI.Helper;
using WebUI.Models.Token;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        public LoginController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("API");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("Auth/Login", model);
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    try
                    {
                        var tokenResponse = JsonConvert.DeserializeObject<JwtToken>(responseContent);

                        if (tokenResponse != null && tokenResponse.Token != null && !string.IsNullOrEmpty(tokenResponse.Token.Result))
                        {
                            var cookieOptions = new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                Expires = DateTime.Now.AddMinutes(60),
                                SameSite = SameSiteMode.None
                            };

                            Response.Cookies.Append("AuthToken", tokenResponse.Token.Result, cookieOptions);
                            var roles = JwtHelper.GetClaimValues(tokenResponse.Token.Result, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

                            var rolesJson = JsonConvert.SerializeObject(roles);
                            Response.Cookies.Append("Roles", rolesJson, cookieOptions);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Token oluşturulamadı.");
                        }
                    }
                    catch (JsonReaderException ex)
                    {
                        ModelState.AddModelError(string.Empty, $"JSON Hatası: {ex.Message}");
                    }
                }
                else
                {
                    var error1Content = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Invalid login attempt. Error: {error1Content}");
                }
            }
            return View(model);
        }




        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Index", "Login");
        }

    }
}
