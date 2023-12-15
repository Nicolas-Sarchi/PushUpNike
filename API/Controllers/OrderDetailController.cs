using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class OrderDetailController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public OrderDetailController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> Get()
        {
            var OrderDetail = await _unitOfWork.OrderDetails.GetAllAsync();
            return mapper.Map<List<OrderDetailDto>>(OrderDetail);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetail>> Post(PostOrderDetailDto OrderDetailDto)
        {
            var OrderDetail = this.mapper.Map<OrderDetail>(OrderDetailDto);
            _unitOfWork.OrderDetails.Add(OrderDetail);
            await _unitOfWork.SaveAsync();
 
            if (OrderDetail == null)
            {
                return BadRequest();
            }
            OrderDetailDto.Id = OrderDetail.Id;
            return CreatedAtAction(nameof(Post), new { id = OrderDetailDto.Id }, OrderDetail);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetailDto>> Get(int id)
        {
            var OrderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            return mapper.Map<OrderDetailDto>(OrderDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostOrderDetailDto>> Put(int id, [FromBody] PostOrderDetailDto OrderDetailDto)
        {
            if (OrderDetailDto == null)
                return NotFound();

            var OrderDetail = this.mapper.Map<OrderDetail>(OrderDetailDto);
            _unitOfWork.OrderDetails.Update(OrderDetail);
            await _unitOfWork.SaveAsync();
            return OrderDetailDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var OrderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if (OrderDetail == null)
                return NotFound();

            _unitOfWork.OrderDetails.Remove(OrderDetail);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}