using Store.Models;

namespace Store.Services
{
    public interface IProductsService
    {
        Task<ICollection<Product>> GetAllAsync();

        Task<ICollection<Product>> GetUserProductsAsync(string id);

        Task<Product> GetAsync(Guid id);

        Task<Product> AddAsync(ProductCreateViewModel product,string UserID);

        Task<Product> UpdateAsync(Product product);

        Task<bool> DeleteAsync(Guid id);
    }
}
