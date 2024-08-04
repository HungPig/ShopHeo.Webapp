using Microsoft.AspNetCore.Mvc;
using ShopHeo.ViewModels.CataLog.Users;
using System.Threading.Tasks;

namespace ShopHeo.AdminApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
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
