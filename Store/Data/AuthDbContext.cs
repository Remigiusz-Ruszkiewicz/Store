using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BasketModel> Basket { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
    }
}
