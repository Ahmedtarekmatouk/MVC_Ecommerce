using Ecommerace.Models;
using Ecommerace.Repositories.AttributeOptions;
using Ecommerace.ViewModels;

namespace Ecommerace.Services.AttributeOptions
{
	public class AttributeOptionsService : IAttributeOptionsService
	{
		IAttributeOptionsRepository Repository;
		public AttributeOptionsService(IAttributeOptionsRepository _Repository)
		{
			Repository = _Repository;
		}
		public void Create(AttributesOptions AttributeOption)
		{
			Repository.Create(AttributeOption);
			Repository.Save();
		}

		public void Delete(int id)
		{
			Repository.Delete(id);
			Repository.Save();
		}

		public void Update(AttributesOptions AttributeOption)
		{
			Repository.Update(AttributeOption);
			Repository.Save();
		}

		public List<AttributesOptions> GetAll()
		{
			return Repository.GetAll();
		}

		public AttributesOptions GetById(int id)
		{
			return Repository.GetById(id);
		}

		public async Task<Dictionary<string, List<AttributesOptions>>> GetAttributesWithAttributesOptions()
		{
			return await Repository.GetAttributesWithAttributesOptions();
		}
		
		public List<AttributesOptions> GetFiltered(string searchText, int page, int pageSize)
		{
			return Repository.GetFiltered(searchText, page, pageSize);
		}

		public PagerViewModel GetPager(string searchText, int page, int pageSize)
		{
			var totalItems = Repository.GetCount(searchText);
			return new PagerViewModel(totalItems, page, pageSize);
		}

	}
}
