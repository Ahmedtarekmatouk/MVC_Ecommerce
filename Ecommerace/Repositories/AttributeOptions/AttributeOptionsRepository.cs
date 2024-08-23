using Ecommerace.Models;
using Ecommerace.Repositories.Attribute;
using Microsoft.EntityFrameworkCore;

namespace Ecommerace.Repositories.AttributeOptions
{
	public class AttributeOptionsRepository : IAttributeOptionsRepository
	{
		private readonly MVCECommeraceContext _context;
        public AttributeOptionsRepository(MVCECommeraceContext _context)
        {
            this._context = _context;
        }
        public void Create(AttributesOptions entity)
		{
			_context.Add(entity);
		}

		public void Delete(int id)
		{
			AttributesOptions entity =GetById(id);
			_context.Remove(entity);
		}

		public List<AttributesOptions> GetAll()
		{
			return _context.AttributesOptions.ToList();
		}

		public AttributesOptions GetById(int id)
		{
			return _context.AttributesOptions.FirstOrDefault(a => a.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(AttributesOptions entity)
		{
			_context.Update(entity);
		}

		public async Task<Dictionary<string, List<AttributesOptions>>> GetAttributesWithAttributesOptions()
		{
			var query = from AttrOp in _context.AttributesOptions
						join Attr in _context.Attributes on AttrOp.AttributeId equals Attr.Id
						group AttrOp by Attr.Name into Group
						select new
						{
							AttributeName = Group.Key,
							Options = Group.ToList()
						};

			var result = await query.ToDictionaryAsync(g => g.AttributeName, g => g.Options);
			return result;
		}

		public IQueryable<AttributesOptions> GetAllAsQuerable()
		{
			return _context.AttributesOptions.AsQueryable();
		}

		public int GetCount(string searchText)
		{
			return string.IsNullOrEmpty(searchText) ?
				_context.AttributesOptions.Count() :
				_context.AttributesOptions.Count(c => c.Value.Contains(searchText));
		}

		public List<AttributesOptions> GetFiltered(string searchText, int page, int pageSize)
		{
			var query = GetAllAsQuerable();
			if (!string.IsNullOrEmpty(searchText))
			{
				query = query.Where(c => c.Value.Contains(searchText)).AsQueryable();
			}

			return query.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.ToList();

		}

	}
}
