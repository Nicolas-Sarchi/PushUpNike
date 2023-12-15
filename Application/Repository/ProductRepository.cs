using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        private readonly NikeDbContext _context;
        public ProductRepository(NikeDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}