using Project.Core.Repositories;
using Project.Data.Entities;

namespace Project.Business.Services
{
    public interface ICartService : IRepository
    {
        void AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, int productId);
    }
}
