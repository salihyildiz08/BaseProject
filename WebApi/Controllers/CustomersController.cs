using BusinessLayer.Abstract;
using DtoLayer.CustomerDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly UserManager<AppUser> _userManager;

        public CustomersController(ICustomerService customerService, UserManager<AppUser> userManager)
        {
            _customerService = customerService;
            _userManager = userManager;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roleClaims = User.FindAll(ClaimTypes.Role);
            var isManager = roleClaims.Any(x => x.Value == "Müdür");
            string representationCode = User.FindFirstValue("representationCode");
            List<BalanceDto> customerBalances = new List<BalanceDto>();

            if (isManager)
            {
                var userCodeList = await UserCodeAsync();

                foreach (var code in userCodeList)
                {
                    try
                    {
                        var balances = await _customerService.GetBalanceByRepresentativeAsync(code);
                        if (balances != null)
                        {
                            customerBalances.AddRange(balances);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata detaylarını loglayın.
                        Console.WriteLine($"Error fetching balance for code {code}: {ex.Message}");
                    }
                }
            }
            else
            {
                try
                {
                    var balances = await _customerService.GetBalanceByRepresentativeAsync(representationCode);
                    if (balances != null)
                    {
                        customerBalances.AddRange(balances);
                    }
                }
                catch (Exception ex)
                {
                    // Hata detaylarını loglayın.
                    Console.WriteLine($"Error fetching balance for representation code {representationCode}: {ex.Message}");
                }
            }

            return Ok(customerBalances);
        }





        public async Task<List<string>> UserCodeAsync()
        {
            List<string> codes = new List<string>();
            var departmentId = User.FindFirstValue("departmentId");

            var users = await _userManager.Users.Where(x => x.DepartmentId == Convert.ToInt32(departmentId)).ToListAsync();

            foreach (var user in users)
            {
                codes.Add(user.RepresentationCode);
            }

            return codes;
        }



    }
}
