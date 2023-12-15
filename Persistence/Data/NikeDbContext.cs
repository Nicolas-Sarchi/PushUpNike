using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class NikeDbContext : DbContext
    {
        public NikeDbContext(DbContextOptions<NikeDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<OrderDetail> OrderDetails {get;set;}


        public DbSet<Role> Roles {get;set;}
        public DbSet<RefreshToken> RefreshTokens {get;set;}

        public DbSet<UserRole> UserRoles {get;set;}




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}