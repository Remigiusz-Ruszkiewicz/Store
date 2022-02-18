using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AuthDbContext dbContext;

        public ProductsService(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await dbContext.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await dbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> AddAsync(ProductCreateViewModel product,string Userid)
        {
            Product product1 = new Product();
            product1.Id = Guid.NewGuid();
            product1.Name = product.Name;
            product1.CategoryId = product.CategoryId;
            product1.Price = product.Price;
            product1.UserId = Userid;
            dbContext.Products.Add(product1);
            await dbContext.SaveChangesAsync();
            var productToReturn = await GetAsync(product1.Id);
            return productToReturn;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            dbContext.Products.Update(product);

            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return false;

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Product>> GetUserProductsAsync(string id)
        {
            return await dbContext.Products.Where(x => x.UserId == id).Include(x => x.Category).ToListAsync();
        }
    }
}
