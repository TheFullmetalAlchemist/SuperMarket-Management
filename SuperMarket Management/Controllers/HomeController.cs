using Microsoft.AspNetCore.Mvc;

namespace SuperMarket_Management.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
