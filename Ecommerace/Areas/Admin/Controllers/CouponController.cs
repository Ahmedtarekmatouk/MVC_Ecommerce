using Ecommerace.Models;
using Ecommerace.Services;
using Ecommerace.Services.Coupons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController : Controller
    {
        ICouponService service;
        IProductsService Pservive;

		public CouponController(ICouponService _Service , IProductsService _Pservive)
        {
            service = _Service;
            Pservive = _Pservive;

        }
        public IActionResult Index(string searchText = "", int page = 1)
        {
            int pageSize = 10;
            var Pager = service.GetPager(searchText, page,pageSize);
            List<Coupon> coupons = service.GetFiltered(searchText, page,pageSize);
            ViewBag.Pager = Pager;
            return View("Index", coupons);
        }

        public IActionResult Add()
        {
            return View("Add");
        }
        
        [HttpPost]
        public IActionResult Add(Coupon CouponFromReq)
        {
            bool flag = true;
            if (ModelState.IsValid == true)
            {
                if (CouponFromReq.DiscountType == 1)
                {
                    if(!(CouponFromReq.DiscountValue>0 && CouponFromReq.DiscountValue <= 100))
                    {
						ModelState.AddModelError("", "Discount Percentage Should Be Between 1% and 100%");
						flag = false;
					}
                }
                if (CouponFromReq.CouponType == 2)
                {
                    if (CouponFromReq.ProductId == null)
                    {
                        ModelState.AddModelError("", "Product Id is Required");
                        flag = false;

                    }
                    else
                    {
                        int productId = CouponFromReq.ProductId ?? 0;

						Products product = Pservive.GetById(productId);
                        if (product == null)
                        {
							ModelState.AddModelError("", "Product Id is invalid");
							flag = false;
						}

					}
                }
                if (CouponFromReq.CouponExpiration == 1)
                {
                    if(!CouponFromReq.StartDate.HasValue || 
                        !CouponFromReq.EndDate.HasValue || 
                        CouponFromReq.StartDate > CouponFromReq.EndDate)
                    {
						ModelState.AddModelError("", "Error in Coupon Expiration start Date/End Date");
						flag = false;
                    }
                }else if (CouponFromReq.CouponExpiration == 2)
				{
					if (!CouponFromReq.UsageLimit.HasValue ||
						!CouponFromReq.UsedCount.HasValue ||
						CouponFromReq.UsageLimit < CouponFromReq.UsedCount)
					{
						ModelState.AddModelError("", "Error in Coupon Expiration Usage Limit/Used Count");
						flag = false;
					}
				}
                //if (!CouponFromReq.CreatedAt.HasValue)
                //{
				CouponFromReq.CreatedAt = DateTime.Now;
                CouponFromReq.UpdatedAt = null;
                //}
                if (flag)
                {
                    service.Create(CouponFromReq);
                    return RedirectToAction("Index");
                }
            }
            return View("Add", CouponFromReq);
        }

        public IActionResult Edit(int id)
        {
            Coupon coupon = service.GetById(id);

			return View("Edit", coupon);
        }

        [HttpPost]
        public IActionResult Edit(Coupon CouponFromReq)
        {
            var CouponFromDb = service.GetById(CouponFromReq.Id);
            if (CouponFromDb != null)
            {
                bool flag = true;
                if (ModelState.IsValid == true)
                {
					if (CouponFromReq.DiscountType == 1)
					{
						if (!(CouponFromReq.DiscountValue > 0 && CouponFromReq.DiscountValue <= 100))
						{
							ModelState.AddModelError("", "Discount Percentage Should Be Between 1% and 100%");
							flag = false;
						}
					}
					if (CouponFromReq.CouponType == 2)
                    {
						if (CouponFromReq.ProductId == null)
						{
							ModelState.AddModelError("", "Product Id is Required");
							flag = false;

						}
						else
						{
							int productId = CouponFromReq.ProductId ?? 0;

							Products product = Pservive.GetById(productId);
							if (product == null)
							{
								ModelState.AddModelError("", "Product Id is invalid");
								flag = false;
							}

						}
					}
                    else if (CouponFromReq.CouponType == 1)
                    {
                        CouponFromReq.ProductId = null;
                    }


                    if (CouponFromReq.CouponExpiration == 1)
                    {
                        CouponFromReq.UsageLimit = null;
                        CouponFromReq.UsedCount = null;

						if (!CouponFromReq.StartDate.HasValue ||
                            !CouponFromReq.EndDate.HasValue ||
                            CouponFromReq.StartDate > CouponFromReq.EndDate)
                        {
                            ModelState.AddModelError("", "Error in Coupon Expiration start Date/End Date");
                            flag = false;
                        }
                    }
                    else if (CouponFromReq.CouponExpiration == 2)
                    {
						CouponFromReq.StartDate = null;
						CouponFromReq.EndDate = null;
						if (!CouponFromReq.UsageLimit.HasValue ||
                            !CouponFromReq.UsedCount.HasValue ||
                            CouponFromReq.UsageLimit < CouponFromReq.UsedCount)
                        {
                            ModelState.AddModelError("", "Error in Coupon Expiration Usage Limit/Used Count");
                            flag = false;
                        }
                    }
                    //if (!CouponFromReq.UpdatedAt.HasValue)
                    //{
                        //CouponFromReq.UpdatedAt = DateTime.Now;
                    //}
                    if (flag)
                    {
                        CouponFromDb.Code = CouponFromReq.Code;
                        CouponFromDb.ProductId = CouponFromReq?.ProductId;
                        CouponFromDb.DiscountType = CouponFromReq.DiscountType;
                        CouponFromDb.DiscountValue = CouponFromReq.DiscountValue;
                        CouponFromDb.StartDate = CouponFromReq?.StartDate;
                        CouponFromDb.EndDate = CouponFromReq?.EndDate;
                        CouponFromDb.UsageLimit = CouponFromReq?.UsageLimit;
                        CouponFromDb.UsedCount = CouponFromReq?.UsedCount;
                        //CouponFromDb.CreatedAt = CouponFromReq?.CreatedAt;
                        CouponFromDb.UpdatedAt = DateTime.Now; ;
                        CouponFromDb.CouponType = CouponFromReq.CouponType;
                        CouponFromDb.CouponExpiration = CouponFromReq.CouponExpiration;
                        service.Update(CouponFromDb);
                        return RedirectToAction("Index");

                    }
                }
            }
            return View("Edit", CouponFromReq);  
            }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
