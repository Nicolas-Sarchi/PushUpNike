using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CategoryRepository : GenericRepository<Category> , ICategory
    {
     private readonly NikeDbContext _context;
        public CategoryRepository(NikeDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Category>> GetAllAsync()
{
 return await _context.Categories.ToListAsync();
}  
}
}