using Microsoft.AspNetCore.Mvc;
using ShopHeo.ViewModels.CataLog.Users;

namespace ShopHeo.AdminApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // design for login user
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            return View();
        }
    }
}
