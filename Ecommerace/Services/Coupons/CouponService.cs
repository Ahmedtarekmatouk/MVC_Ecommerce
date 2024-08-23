using Ecommerace.Models;
using Ecommerace.Repositories.Coupons;
using Ecommerace.ViewModels;

namespace Ecommerace.Services.Coupons
{
    public class CouponService : ICouponService //should inject CouponRepository
    {
        ICouponRepository Repository;
        public CouponService(ICouponRepository _Repository)
        {
            Repository = _Repository;
        }

        public List<Coupon> GetAll()
        {
            return Repository.GetAll();
        }

        public void Create(Coupon coupon)
        {
            Repository.Create(coupon);
            Repository.Save();
        }

        public void Update(Coupon coupon)
        {
            Repository.Update(coupon);
            Repository.Save();
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
            Repository.Save();
        }

        public Coupon GetById(int id)
        {
            return Repository.GetById(id);
        }

        public PagerViewModel GetPager(string searchText, int page, int pageSize)
        {
            int totalItems = Repository.GetCount(searchText);
            return new PagerViewModel(totalItems, page, pageSize);
        }
        public List<Coupon> GetFiltered(string searchText, int page, int pageSize)
        {
            return Repository.GetFiltered(searchText, page, pageSize);
        }

    }
}
