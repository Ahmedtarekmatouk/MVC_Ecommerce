using Ecommerace.Models;
using Ecommerace.Services.ShippingMethod;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippingMethodsController : Controller
    {
        IShippingMethodsService _shippingMethodsService;
        public ShippingMethodsController(IShippingMethodsService shippingMethodsService)
        {
            _shippingMethodsService = shippingMethodsService;
        }
        public IActionResult GetAll(string search, int pageIndex = 1, int pageSize = 10)
        {
            IEnumerable<ShippingMethods> items;

            if (string.IsNullOrEmpty(search))
            {
                items = _shippingMethodsService.GetAll();
            }
            else
            {
                items = _shippingMethodsService.GetByName(search);
            }
            var count = items.Count();
            var paginatedItems = items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            var paginatedList = new Pagination<ShippingMethods>(paginatedItems, count, pageIndex, pageSize);

            return View(paginatedList);
        }


        public IActionResult Delete(int id)
        {
            _shippingMethodsService.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult Details(ShippingMethods ShippingMethods)
        {
            return View("Edite", _shippingMethodsService.GetById(ShippingMethods.Id));
        }
        public IActionResult Update(ShippingMethods ShippingMethods)
        {
            _shippingMethodsService.Update(ShippingMethods);
            return RedirectToAction("GetAll");
        }
        public IActionResult Add_New()
        {
            return View("AddNew");
        }
        public IActionResult Create(ShippingMethods ShippingMethods)
        {
            if (ShippingMethods.Name != null)
            {
                _shippingMethodsService.Create(ShippingMethods);
                return RedirectToAction("GetAll");
            }
            return View("AddNew", ShippingMethods);
        }
    }
}
