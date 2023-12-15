using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public OrderController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var Order = await _unitOfWork.Orders.GetAllAsync();
            return mapper.Map<List<OrderDto>>(Order);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Post(PostOrderDto OrderDto)
        {
            var Order = this.mapper.Map<Order>(OrderDto);
            _unitOfWork.Orders.Add(Order);
            await _unitOfWork.SaveAsync();
 
            if (Order == null)
            {
                return BadRequest();
            }
            OrderDto.Id = Order.Id;
            return CreatedAtAction(nameof(Post), new { id = OrderDto.Id }, Order);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var Order = await _unitOfWork.Orders.GetByIdAsync(id);
            return mapper.Map<OrderDto>(Order);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostOrderDto>> Put(int id, [FromBody] PostOrderDto OrderDto)
        {
            if (OrderDto == null)
                return NotFound();

            var Order = this.mapper.Map<Order>(OrderDto);
            _unitOfWork.Orders.Update(Order);
            await _unitOfWork.SaveAsync();
            return OrderDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (Order == null)
                return NotFound();

            _unitOfWork.Orders.Remove(Order);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}