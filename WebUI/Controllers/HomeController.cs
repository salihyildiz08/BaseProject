using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Linq;
using WebUI.Dtos.CustomerDtos;
using WebUI.Dtos.MeetingDtos;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly HttpClient _httpClient;

        public HomeController(IConfiguration configuration, IHttpClientFactory httpClient)
            : base(configuration)
        {
            _httpClient = httpClient.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {

            var response1 = await _httpClient.GetFromJsonAsync<List<BalanceDto>>($"Customers");
            if (response1 != null)
            {
                return View(response1);
            }

            return View();
        }


        public async Task<IActionResult> Gorusmelerim()
        {
            var response1 = await _httpClient.GetFromJsonAsync<List<ResultMeetingDto>>($"Meetings/MeetingListForMe");
            if (response1 != null)
            {
                return View(response1);
            }

            return View();
        }

        public async Task<IActionResult> List(string name)
        {
            var response1 = await _httpClient.GetFromJsonAsync<List<ResultMeetingDto>>($"Meetings/MeetingList/{name}");
            if (response1 != null)
            {
                return View(response1);
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Create(string name)
        {
            ViewBag.Name = name;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingDto createMeetingDto)
        {
            string name = createMeetingDto.VisitedCompany;
            var responseMessage = await _httpClient.PostAsJsonAsync("Meetings/CreateMeeting", createMeetingDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("List", new { name = createMeetingDto.VisitedCompany });
            }
            return RedirectToAction("Create", new { name = createMeetingDto.VisitedCompany });

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var token = Request.Cookies["AuthToken"];
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            var response1 = await _httpClient.GetFromJsonAsync<ResultMeetingDto>($"Meetings/MeetingGetById/{id}");
            if (response1 != null)
            {
                return View(response1);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMeetingDto updateMeetingDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("Meetings/UpdateMeeting", updateMeetingDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("List", new { name = updateMeetingDto.VisitedCompany });
            }
            return RedirectToAction("Update", new { id = updateMeetingDto.ID });
        }



        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var response1 = await _httpClient.GetFromJsonAsync<ResultMeetingDto>($"Meetings/MeetingGetById/{id}");
            if (response1 != null)
            {
                return View(response1);
            }

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
