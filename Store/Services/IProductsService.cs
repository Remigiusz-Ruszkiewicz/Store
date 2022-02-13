using Store.Models;

namespace Store.Services
{
    public interface IProductsService
    {
        Task<ICollection<Product>> GetAllAsync();

        Task<Product> GetAsync(Guid id);

        Task<Product> AddAsync(ProductCreateViewModel product);

        Task<Product> UpdateAsync(Product product);

        Task<bool> DeleteAsync(Guid id);
    }
}
