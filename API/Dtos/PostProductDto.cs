using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PostProductDto 
    {
         public string ProductId {get;set;}
        public string Title {get;set;}
        public string Image { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}