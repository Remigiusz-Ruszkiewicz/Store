using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Models;
using Store.Services;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productsService.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            return View(new ProductCreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel product)
        {
            await productsService.AddAsync(product, Request.Cookies["loginCookie"]);
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> Update(Product product)
        {
            await productsService.UpdateAsync(product);
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> Edit(Product product)
        {
            return View(product);
        }
        public async Task<IActionResult> Delete(string id)
        {
            await productsService.DeleteAsync(Guid.Parse(id));
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> Put(Product product)
        {
            await productsService.UpdateAsync(product);
            return RedirectToAction("Index", "Products");
        }
        
    }
}
