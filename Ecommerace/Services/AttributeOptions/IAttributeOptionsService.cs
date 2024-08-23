using Ecommerace.Models;
using Ecommerace.ViewModels;

namespace Ecommerace.Services.AttributeOptions
{
    public interface IAttributeOptionsService:IService
    {
		List<AttributesOptions> GetAll();

		public void Create(AttributesOptions Attribute);

		public void Update(AttributesOptions Attribute);

		public void Delete(int id);

		public Task<Dictionary<string, List<AttributesOptions>>> GetAttributesWithAttributesOptions();
		public AttributesOptions GetById(int id);

		public List<AttributesOptions> GetFiltered(string searchText, int page, int pageSize);

		public PagerViewModel GetPager(string searchText, int page, int pageSize);
	}
}
