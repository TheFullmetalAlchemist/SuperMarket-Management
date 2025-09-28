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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);
            return View(category);            ;
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            ViewBag.Action = "edit";

            if (ModelState.IsValid) 
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Add()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {

            ViewBag.Action = "add";
            if (ModelState.IsValid) 
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }   
            return View(category);
        }


        [HttpPost]
        public IActionResult Delete (int categoryId)
        {
            CategoriesRepository.DeleteCategory(categoryId);

            return RedirectToAction(nameof(Index));
        }

    }
}
