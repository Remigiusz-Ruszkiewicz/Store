using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string UserId { get; set; }
    }
}
