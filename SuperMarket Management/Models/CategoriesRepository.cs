using System.ComponentModel.DataAnnotations;

namespace SuperMarket_Management.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
            {
               new Category{ CategoryId=1,Description = "Beverage",Name="Beverage" },
               new Category{ CategoryId=2,Description = "Meat", Name="Meat"},
               new Category{ CategoryId=3,Description = "Bakery", Name="Bakery"}
            
            };

        public static List<Category> GetCategories() => _categories;

        public static void AddCategory(Category category)
        {

            var MaxId = _categories.Select(x => x.CategoryId).DefaultIfEmpty(0).Max();
            category.CategoryId = MaxId + 1;
            _categories.Add(category);
        }

        public static Category? GetCategoryById( int categoryId)
        {
            var category = _categories.FirstOrDefault(x=>x.CategoryId == categoryId);
            if(category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Description = category.Description,
                    Name = category.Name

                };
            }
            return null;
        }
        public static void UpdateCategory(int categoryId, Category category)
        {
            var existingCategory = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
        }
        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x=>x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }


    }
}
