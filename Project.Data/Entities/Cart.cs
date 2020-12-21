using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
    }
}
