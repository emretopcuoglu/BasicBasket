using Project.Core.Repositories;
using Project.Data.Entities;

namespace Project.Business.Services
{
    public interface IProductService : IRepository
    {
        Product GetById(int productId, Cart cart);
    }
}
