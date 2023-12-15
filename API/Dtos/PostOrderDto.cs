using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PostOrderDto: BaseDto
    {
        public int UserId { get; set; }

        public DateTime Date {get;set;}
        public double Total { get; set; }
    }
}