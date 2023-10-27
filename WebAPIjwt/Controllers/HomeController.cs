using Microsoft.AspNetCore.Mvc;

namespace WebAPIjwt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
