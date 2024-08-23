using Ecommerace.Models;

namespace Ecommerace.Repositories.AttributeOptions
{
	public interface IAttributeOptionsRepository:IRepository<AttributesOptions>
	{
		public Task<Dictionary<string, List<AttributesOptions>>> GetAttributesWithAttributesOptions();

		IQueryable<AttributesOptions> GetAllAsQuerable();

		int GetCount(string searchText);

		List<AttributesOptions> GetFiltered(string searchText, int page, int pageSize);
	}
}
