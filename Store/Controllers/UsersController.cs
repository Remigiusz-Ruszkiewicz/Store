using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Services;

namespace Store.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            UserModel result = usersService.LoginAsync(user.UserName, user.Password).Result;

            Response.Cookies.Append("loginCookie", result.Id.ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(7)});

            return RedirectToAction("Index", "Products");
        }
    }
}
