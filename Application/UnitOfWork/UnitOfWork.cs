using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;
    public class UnitOfWork : IUnitOfWork

    {
        private readonly NikeDbContext context;
        private UserRepository _Users;
        private CategoryRepository _Categories;
        private OrderRepository _Orders;
        private OrderDetailRepository _OrderDetails;
        private ProductRepository _Products;
        private RoleRepository _Roles;



        public UnitOfWork(NikeDbContext _context)
        {
            context = _context;
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(context);
                }
                return _Users;
            }
        }
         public ICategory Categories
        {
            get
            {
                if (_Categories == null)
                {
                    _Categories = new CategoryRepository(context);
                }
                return _Categories;
            }
        }
         public IOrder Orders
        {
            get
            {
                if (_Orders == null)
                {
                    _Orders = new OrderRepository(context);
                }
                return _Orders;
            }
        }
         public IOrderDetail OrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                {
                    _OrderDetails = new OrderDetailRepository(context);
                }
                return _OrderDetails;
            }
        }
         public IProduct Products
        {
            get
            {
                if (_Products == null)
                {
                    _Products = new ProductRepository(context);
                }
                return _Products;
            }
        }
         public IRole Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RoleRepository(context);
                }
                return _Roles;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }