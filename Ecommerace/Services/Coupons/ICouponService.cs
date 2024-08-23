using Ecommerace.Models;
using Ecommerace.Repositories;
using Ecommerace.ViewModels;

namespace Ecommerace.Services.Coupons
{
    public interface ICouponService : IService
    {
        List<Coupon> GetAll();

        public void Create(Coupon coupon);

        public void Update(Coupon coupon);

        public void Delete(int id);

        public Coupon GetById(int id);

        public List<Coupon> GetFiltered(string searchText, int page, int pageSize);

        public PagerViewModel GetPager(string searchText, int page, int pageSize);
    }
}
