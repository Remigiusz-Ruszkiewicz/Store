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
            var products = await productsService.GetAllAsync();
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
            await productsService.AddAsync(product);
            return RedirectToAction("Index", "Products");
        }
    }
}
