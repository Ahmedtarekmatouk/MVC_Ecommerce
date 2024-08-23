using Ecommerace.Models;
using Ecommerace.Repositories.Attribute;
using Ecommerace.ViewModels;

namespace Ecommerace.Services.Attribute
{
	public class AttributesService : IAttributesService
	{
		IAttributesRepository Repository;
        public AttributesService(IAttributesRepository _Repository)
        {
            Repository = _Repository;
        }
        public void Create(ProductAttributes Attribute)
		{
			Repository.Create(Attribute);
			Repository.Save();
		}

		public void Delete(int id)
		{
			Repository.Delete(id);
			Repository.Save();
		}

		public List<ProductAttributes> GetAll()
		{
			return Repository.GetAll();
		}

		public ProductAttributes GetById(int id)
		{
			return Repository.GetById(id);
		}

		public List<ProductAttributes> GetFiltered(string searchText, int page, int pageSize)
		{
			return Repository.GetFiltered(searchText, page, pageSize);
		}

		public PagerViewModel GetPager(string searchText, int page, int pageSize)
		{
			var totalItems = Repository.GetCount(searchText);
			return new PagerViewModel(totalItems,page,pageSize);
		}

		public void Update(ProductAttributes Attribute)
		{
			Repository.Update(Attribute);
			Repository.Save();
		}
	}
}
