using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategory Categories { get; }
        public IOrder Orders { get; }
        public IOrderDetail OrderDetails { get; }
        public IProduct Products { get; }
        public IRole Roles { get; }
        public IUser Users { get; }
        Task<int> SaveAsync();
    }
}