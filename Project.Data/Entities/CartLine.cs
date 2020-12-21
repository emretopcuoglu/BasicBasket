using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
