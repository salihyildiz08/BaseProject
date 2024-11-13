using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MeetingDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public MeetingsController(IMeetingService meetingsService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _meetingService = meetingsService;
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpGet("MeetingList/{name}")]
        public async Task<IActionResult> MeetingList(string name)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            var departmentId = User.FindFirstValue("departmentId");

            List<Meeting> meetings;

            if (role == "Müdür")
            {
                meetings = await _meetingService.GetWhere(x => x.DepartmentId == Convert.ToInt32(departmentId) && x.VisitedCompany == name).ToListAsync();
            }
            else
            {
                meetings = await _meetingService.GetWhere(x => x.CreateUserID == Convert.ToInt32(userId) && x.VisitedCompany == name).ToListAsync();
            }

            var result = _mapper.Map<List<ResultMeetingDto>>(meetings);
            return Ok(result);
        }


        [HttpGet("MeetingListForMe")]
        public async Task<IActionResult> MeetingListForMe()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var role = User.FindFirstValue(ClaimTypes.Role);
                var departmentId = User.FindFirstValue("departmentId");

                List<Meeting> meetings;

                if (role == "Müdür")
                {
                    meetings = await _meetingService.GetWhere(x => x.DepartmentId == Convert.ToInt32(departmentId))
                                                     .Include(x => x.CreateAppUser)
                                                     .ToListAsync();
                }
                else if (role == "Admin")
                {
                    meetings = await _meetingService.GetWhere(x => x.CreateDate != null)
                                                     .Include(x => x.CreateAppUser)
                                                     .ToListAsync();
                }
                else
                {
                    meetings = await _meetingService.GetWhere(x => x.CreateUserID == Convert.ToInt32(userId))
                                                     .Include(x => x.CreateAppUser)
                                                     .ToListAsync();
                }

                var result = meetings.Select(meeting => new ResultMeetingDto
                {
                    ID = meeting.ID,
                    Title = meeting.Title,
                    Description = meeting.Description,
                    VisitedCompany = meeting.VisitedCompany,
                    CompanyDemands = meeting.CompanyDemands,
                    IsCollection = meeting.IsCollection,
                    CollectionTotal = meeting.CollectionTotal,
                    CollectionType = meeting.CollectionType,
                    Currency = meeting.Currency,
                    CreateDate = meeting.CreateDate,
                    CreateUserID = meeting.CreateUserID,
                    CreateUserName = $"{meeting.CreateAppUser.Name} {meeting.CreateAppUser.Surname}",
                    UpdateDate = meeting.UpdateDate,
                    UpdateUserID = meeting.UpdateUserID,
                    DepartmentId = meeting.DepartmentId
                }).ToList();

                return Ok(result);

            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpPost("CreateMeeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var departmentId = User.FindFirstValue("departmentId");
            dto.DepartmentId = Convert.ToInt32(departmentId);

            dto.CreateUserID = string.IsNullOrEmpty(userId) ? 0 : int.Parse(userId);
            dto.UpdateUserID = string.IsNullOrEmpty(userId) ? 0 : int.Parse(userId);
            dto.CreateDate = DateTime.Now;
            dto.UpdateDate = DateTime.Now;

            var meeting = _mapper.Map<Meeting>(dto);
            _meetingService.Add(meeting);

            return Ok(meeting);
        }


        [HttpGet("MeetingGetById/{id}")]
        public async Task<IActionResult> MeetingGetById(int id)
        {
            var meeting = await _meetingService.GetByIdAsync(x => x.ID == id);
            var user = await _userManager.FindByIdAsync(Convert.ToString(meeting.CreateUserID));
            var values = _mapper.Map<ResultMeetingDto>(meeting);
            values.CreateUserName = user.Name+" "+user.Surname;
            return Ok(values);
        }


        [HttpPost("UpdateMeeting")]
        public async Task<IActionResult> UpdateMeeting([FromBody] UpdateMeetingDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var departmentId = User.FindFirstValue("departmentId");
            dto.DepartmentId = Convert.ToInt32(departmentId);
            dto.UpdateUserID = string.IsNullOrEmpty(userId) ? 0 : int.Parse(userId);
            dto.UpdateDate = DateTime.Now;
            var existingTalep = await _meetingService.GetByIdAsync(x => x.ID == dto.ID);
            if (existingTalep == null)
            {
                return NotFound("meeting not found");
            }

            _mapper.Map(dto, existingTalep);
            _meetingService.Update(existingTalep);
            return Ok("Update successful");
        }


    }
}
