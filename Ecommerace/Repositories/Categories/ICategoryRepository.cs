using Ecommerace.Models;

namespace Ecommerace.Repositories.Categories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoryTree(); // <>
    }
}
