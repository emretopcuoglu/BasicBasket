using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Data.Entities;
using Project.Data.EntityFramework;

namespace Project.Business.Services
{
    public class ProductService : IProductService
    {
        private DatabaseContext _db;

        public ProductService(DatabaseContext databaseContext)
        {
            _db = databaseContext;
        }

        public Product GetById(int productId, Cart cart)
        {
            var product = _db.Product.Where(x => x.ProductId == productId).SingleOrDefault();

            var cartCount = CartCount(cart, productId);

            if (product != null && product.Stock > 0 && product.Stock > cartCount)
            {
                return product;
            }
            return null;
        }

        public int CartCount(Cart cart, int productId)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
            int cartCount = 0;
            if (cartLine != null)
            {
                cartCount = cartLine.Quantity;
            }
            return cartCount;
        }
    }
}
