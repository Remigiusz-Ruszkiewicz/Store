using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Models;
using Store.Services;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var CookieValue = Request.Cookies["loginCookie"];
            var products = await productsService.GetUserProductsAsync(CookieValue);
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            var createProductViewModel = new ProductCreateViewModel();
            var categories = await categoriesService.GetAllAsync();
            createProductViewModel.Categories = new SelectList(categories, nameof(CategoryViewModel.Id), nameof(CategoryViewModel.Name));

            return View(createProductViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel product)
        {
            await productsService.AddAsync(product, Request.Cookies["loginCookie"]);
            return RedirectToAction("Index", "Products");
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
