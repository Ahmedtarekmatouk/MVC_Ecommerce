using Ecommerace.Models;

namespace Ecommerace.Repositories.Attribute
{
	public interface IAttributesRepository : IRepository<ProductAttributes>
	{
		IQueryable<ProductAttributes> GetAllAsQuerable();

		int GetCount(string searchText);

		List<ProductAttributes> GetFiltered(string searchText, int page, int pageSize);

	}
}
