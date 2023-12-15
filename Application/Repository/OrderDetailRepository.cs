using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail> , IOrderDetail
    {
     private readonly NikeDbContext _context;
        public OrderDetailRepository(NikeDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<OrderDetail>> GetAllAsync()
{
 return await _context.OrderDetails.Include(od => od.Product).ToListAsync();
}  
}
}