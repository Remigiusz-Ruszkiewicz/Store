using Store.Models;

namespace Store.Services
{
    public interface IUsersService
    {
        Task<UserModel> AddAsync(string email, string password);
        Task<UserModel> LoginAsync(string email, string password);
    }
}
