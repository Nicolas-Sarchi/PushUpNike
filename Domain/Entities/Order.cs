using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order  : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime Date {get;set;}
        public double Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}