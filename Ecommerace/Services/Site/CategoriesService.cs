using Ecommerace.Models;
using Ecommerace.Repositories.Categories;

namespace Ecommerace.Services.Site
{
    public class CategoriesService : ICategoriesService
    {
        ICategoryRepository _repo;
        public CategoriesService(ICategoryRepository categoryRepository) {
            _repo = categoryRepository;
        }

        public List<Category> GetCategoriesTree()
        {
            return  _repo.GetCategoryTree();

        }
    }
}
