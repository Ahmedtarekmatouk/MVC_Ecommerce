using Ecommerace.Models;

namespace Ecommerace.Services.Site
{
    public interface ICategoriesService : IService
    {
        public List<Category> GetCategoriesTree();
    }
}
