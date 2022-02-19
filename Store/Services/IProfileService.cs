using Store.Models;

namespace Store.Services
{
    public interface IProfileService
    {
        Task<Product> UpdateAsync(Product product);
    }
}
