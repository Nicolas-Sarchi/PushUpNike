using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CategoryController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var Category = await _unitOfWork.Categories.GetAllAsync();
            return mapper.Map<List<CategoryDto>>(Category);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> Post(CategoryDto CategoryDto)
        {
            var Category = this.mapper.Map<Category>(CategoryDto);
            _unitOfWork.Categories.Add(Category);
            await _unitOfWork.SaveAsync();
 
            if (Category == null)
            {
                return BadRequest();
            }
            CategoryDto.Id = Category.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoryDto.Id }, Category);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var Category = await _unitOfWork.Categories.GetByIdAsync(id);
            return mapper.Map<CategoryDto>(Category);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> Put(int id, [FromBody] CategoryDto CategoryDto)
        {
            if (CategoryDto == null)
                return NotFound();

            var Category = this.mapper.Map<Category>(CategoryDto);
            _unitOfWork.Categories.Update(Category);
            await _unitOfWork.SaveAsync();
            return CategoryDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (Category == null)
                return NotFound();

            _unitOfWork.Categories.Remove(Category);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}