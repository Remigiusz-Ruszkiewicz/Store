using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Models
{
    public class ProductCreateViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
