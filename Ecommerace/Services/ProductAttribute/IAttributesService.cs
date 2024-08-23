using Ecommerace.Models;
using Ecommerace.ViewModels;

namespace Ecommerace.Services.Attribute
{
    public interface IAttributesService : IService
    {
		List<ProductAttributes> GetAll();

		public void Create(ProductAttributes Attribute);

		public void Update(ProductAttributes Attribute);

		public void Delete(int id);

		public ProductAttributes GetById(int id);

		public List<ProductAttributes> GetFiltered(string searchText, int page, int pageSize);

		public PagerViewModel GetPager(string searchText, int page, int pageSize);
	}
}
