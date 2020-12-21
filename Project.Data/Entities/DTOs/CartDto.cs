using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Entities.DTOs
{
    public class CartDto
    {
        public CartDto()
        {
            CartLines = new List<CartLineDto>();
        }
        public List<CartLineDto> CartLines { get; set; }
    }
}
