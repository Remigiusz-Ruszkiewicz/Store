using Store.Models;

namespace Store.Services
{
    public interface ICategoriesService
    {
        Task<CategoryViewModel> AddAsync(CategoryViewModel category);
        Task<ICollection<CategoryViewModel>> GetAllAsync();
    }
}
