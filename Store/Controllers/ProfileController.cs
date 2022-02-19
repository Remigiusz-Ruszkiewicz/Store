using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Services;
using System.Diagnostics;

namespace Store.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProductsService productsService;

        public ProfileController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var CookieValue = Request.Cookies["loginCookie"];
            var products = await productsService.GetUserProductsAsync(CookieValue);
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
            return RedirectToAction("Index", "Profile");
        }
        public async Task<IActionResult> Put(Product product)
        {
            await productsService.UpdateAsync(product);
            return RedirectToAction("Index", "Products");
        }
    }
}