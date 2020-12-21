using ContactReport.Core;
using Project.Data.Entities;
using Project.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Business.Services
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            if (product == null)
            {
                throw new Exception("Ürün stokta bulunmamaktadır.");
            }

            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);

            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);

            if (cartLine != null && cartLine.Quantity > 0)
            {
                cartLine.Quantity--;
                if (cartLine.Quantity == 0)
                {
                    cart.CartLines.Remove(cartLine);
                }
                return;
            }
            else
            {
                throw new Exception("Sepetinizde ilgili ürün zaten bulunmamaktadır.");
            }
        }
    }
}
