using Microsoft.AspNetCore.Mvc;

namespace planetary_api.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}