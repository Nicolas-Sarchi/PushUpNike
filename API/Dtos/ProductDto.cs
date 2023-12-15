using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductDto : BaseDto
    {
         public string ProductId {get;set;}
        public string Title {get;set;}
        public string Image { get; set; }
        public double Price { get; set; }
        public CategoryDto Category { get; set; }
    }
}