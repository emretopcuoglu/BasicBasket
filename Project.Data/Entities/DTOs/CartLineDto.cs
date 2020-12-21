using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Entities.DTOs
{
    public class CartLineDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
