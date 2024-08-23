using Ecommerace.Models;

namespace Ecommerace.Services.Categories
{
    public interface ICategoryService : IService
    {
        void CreateCategory(Category category);
        void UpdateCategory(Category category);

        void DeleteCategory(int id);
        void saveChanges();
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();


    }
}
