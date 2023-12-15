using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var Product = await _unitOfWork.Products.GetAllAsync();
            return mapper.Map<List<ProductDto>>(Product);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(ProductDto ProductDto)
        {
            var Product = this.mapper.Map<Product>(ProductDto);
            _unitOfWork.Products.Add(Product);
            await _unitOfWork.SaveAsync();
 
            if (Product == null)
            {
                return BadRequest();
            }
            ProductDto.Id = Product.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductDto.Id }, Product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var Product = await _unitOfWork.Products.GetByIdAsync(id);
            return mapper.Map<ProductDto>(Product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostProductDto>> Put(int id, [FromBody] PostProductDto ProductDto)
        {
            if (ProductDto == null)
                return NotFound();

            var Product = this.mapper.Map<Product>(ProductDto);
            _unitOfWork.Products.Update(Product);
            await _unitOfWork.SaveAsync();
            return ProductDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _unitOfWork.Products.GetByIdAsync(id);
            if (Product == null)
                return NotFound();

            _unitOfWork.Products.Remove(Product);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}