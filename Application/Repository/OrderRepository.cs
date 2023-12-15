using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        private readonly NikeDbContext _context;
        public OrderRepository(NikeDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.User).ToListAsync();
        }
    }
}