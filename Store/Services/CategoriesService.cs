using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AuthDbContext dbContext;
        public CategoriesService(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CategoryViewModel> AddAsync(CategoryViewModel category)
        {

            dbContext.CategoryViewModel.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<ICollection<CategoryViewModel>> GetAllAsync()
        {
            return await dbContext.CategoryViewModel.ToListAsync();
        }
    }
}
