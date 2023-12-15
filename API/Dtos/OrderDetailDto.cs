using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrderDetailDto : BaseDto
    {
        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}