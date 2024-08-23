using Ecommerace.Models;
using NuGet.Protocol.Core.Types;

namespace Ecommerace.Repositories.Coupons
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MVCECommeraceContext _context;

        public CouponRepository(MVCECommeraceContext _context)
        {
            this._context = _context;
        }

        public List<Coupon> GetAll()
        {
            return _context.Coupon.ToList();
        }

        public void Create(Coupon entity)
        {
			_context.Add(entity);
		}

        public void Delete(int id)
        {
			Coupon entity = GetById(id);
			_context.Remove(entity);
		}

        public Coupon GetById(int id)
        {
			return _context.Coupon.FirstOrDefault(c => c.Id == id);
		}

        public void Save()
        {
			_context.SaveChanges();
		}

        public void Update(Coupon entity)
        {
			_context.Update(entity);
		}

		public IQueryable<Coupon> GetAllAsQuerable()
		{
			return _context.Coupon.AsQueryable();
		}

		public int GetCount(string searchText)
		{
			return string.IsNullOrEmpty(searchText) ?
				_context.Coupon.Count() : 
				_context.Coupon.Count(c => c.Code.Contains(searchText)); 
		}

		public List<Coupon> GetFiltered(string searchText, int page, int pageSize)
		{
			var query = GetAllAsQuerable();
			if (!string.IsNullOrEmpty(searchText))
			{
				query = query.Where(c => c.Code.Contains(searchText)).AsQueryable();
			}

			return query.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.ToList();

		}
	}
}
