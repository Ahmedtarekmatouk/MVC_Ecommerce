using Ecommerace.Models;

namespace Ecommerace.Repositories.Attribute
{
	public class AttributesRepository : IAttributesRepository
	{
		private readonly MVCECommeraceContext _context;

		public AttributesRepository(MVCECommeraceContext _context)
		{
			this._context = _context;
		}

		public List<ProductAttributes> GetAll()
		{
			return _context.Attributes.ToList();
		}

		public void Create(ProductAttributes entity)
		{
			_context.Add(entity);
		}

		public void Delete(int id)
		{
            ProductAttributes entity = GetById(id);
			_context.Remove(entity);
		}

		public ProductAttributes GetById(int id)
		{
			return _context.Attributes.FirstOrDefault(c => c.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(ProductAttributes entity)
		{
			_context.Update(entity);
		}

		public IQueryable<ProductAttributes> GetAllAsQuerable()
		{
			return _context.Attributes.AsQueryable();
		}

		public int GetCount(string searchText)
		{
			return string.IsNullOrEmpty(searchText) ?
				_context.Attributes.Count() :
				_context.Attributes.Count(c => c.Name.Contains(searchText));
		}

		public List<ProductAttributes> GetFiltered(string searchText, int page, int pageSize)
		{
			var query = GetAllAsQuerable();
			if (!string.IsNullOrEmpty(searchText))
			{
				query = query.Where(c => c.Name.Contains(searchText)).AsQueryable();
			}

			return query.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.ToList();

		}
	}
}
