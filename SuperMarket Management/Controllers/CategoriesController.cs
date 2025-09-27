using Microsoft.AspNetCore.Mvc;
using SuperMarket_Management.Models;

namespace SuperMarket_Management.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int id)
        {
            var category = new Category
            {
                CategoryId = id,
                Name = "Sample Category",
                Description = "This is a sample category description."
            };
            return View(category);            ;
        }
    }
}
