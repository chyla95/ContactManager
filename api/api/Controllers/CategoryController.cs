using api.Dtos.Category;
using api.Dtos.Contact;
using api.Exceptions;
using api.Models;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponseDto>>> GetMany()
        {
            IEnumerable<Category> categories = await _categoryService.GetManyAsync();

            IEnumerable<CategoryResponseDto> response = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactResponseDto>> Get(int id)
        {
            Category? category = await _categoryService.GetAsync(id);
            if (category == null) throw new HttpNotFoundException("Category not found!");

            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
            return Ok(response);
        }
    }
}
