using Store.Data;
using Store.Models;

namespace Store.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AuthDbContext dbContext;
        public ProfileService(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> UpdateAsync(Product product)
        {
            await dbContext.Products.Update(product).ReloadAsync();

            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
