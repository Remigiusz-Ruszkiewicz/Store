using Store.Models;

namespace Store.Services
{
    public interface IBasketService
    {
        Task<ICollection<Product>> GetAllAsync(string UserID);
        Task<bool> AddAsync(string Id, string UserID);
        Task<bool> DeleteAsync(string id);
    }
}
