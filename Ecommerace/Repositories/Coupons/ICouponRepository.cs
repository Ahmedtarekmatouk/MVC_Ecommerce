using Ecommerace.Models;

namespace Ecommerace.Repositories.Coupons
{
    public interface ICouponRepository : IRepository<Coupon>
    {
        IQueryable<Coupon> GetAllAsQuerable();

        int GetCount(string searchText);

		List<Coupon> GetFiltered(string searchText, int page, int pageSize);


	}
}
