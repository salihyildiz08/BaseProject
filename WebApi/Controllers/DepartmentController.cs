using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DepartmentDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DepartmentList()
        {
            var values = _mapper.Map<List<ResultDepartmentDto>>(_departmentService.GetWhere(x => x.Statu != null));
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateAbout(CreateDepartmantDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            _departmentService.Add(department);

            return Ok("Successfull");
        }
    }
}