using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Services
{
    public class BasketService : IBasketService
    {
        private readonly AuthDbContext dbContext;
        public BasketService(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddAsync(string Id, string UserID)
        {
            BasketModel basketItem = new BasketModel();
            basketItem.Id = Guid.NewGuid();
            basketItem.ProductId = Id;
            basketItem.UserId = UserID;
            dbContext.Basket.Add(basketItem);
            bool isSuccesfull = dbContext.SaveChangesAsync().IsCompletedSuccessfully;
            if (isSuccesfull)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await dbContext.Basket.Where(x => x.ProductId == id.ToString()).SingleOrDefaultAsync();
            if (product == null)
                return false;

            dbContext.Basket.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Product>> GetAllAsync(string UserId)
        {
            List<Product> product = new List<Product>();
            List<string> basketProducts = await dbContext.Basket.Where(u=>u.UserId==UserId).Select(x => x.ProductId).ToListAsync();
            foreach (var item in basketProducts)
            {
                var basketProduct = await dbContext.Products.Where(x => x.Id.ToString() == item.ToUpper()).SingleOrDefaultAsync();
                    if (basketProduct != null)
                {
                    product.Add(basketProduct);
                }
                
            }
            return product;
        }
    }
}
