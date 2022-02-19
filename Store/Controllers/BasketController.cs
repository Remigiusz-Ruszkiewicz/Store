using Microsoft.AspNetCore.Mvc;
using Store.Services;

namespace Store.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await basketService.GetAllAsync(Request.Cookies["loginCookie"]);
            if (products!=null)
            {
                return View(products);
            }
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> RemoveFromBasket(string id)
        {
           // await productsService.DeleteAsync(Guid.Parse(id));
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> AddToCart(string id)
        {
            await basketService.AddAsync(id, Request.Cookies["loginCookie"]);
            return RedirectToAction("Index", "Products");
        }
    }
}
