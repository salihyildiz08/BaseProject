using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetWhere(x => x.Name != null).ToListAsync();
            var values = _mapper.Map<List<ResultCategoryDto>>(categories);
            return Ok(values);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _categoryService.Add(category);

            return Ok(category);
        }

    }
}
