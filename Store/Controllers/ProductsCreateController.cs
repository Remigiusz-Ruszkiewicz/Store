using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class ProductsCreateController : Controller
    {
        public IActionResult Dodaj()
        {
            return View();
        }
    }
}
