using Ecommerace.Models;
using Ecommerace.Services.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AttributesController : Controller
	{
		private readonly IAttributesService Service;
		public AttributesController(IAttributesService _Service)
        {
            Service = _Service;
        }
        public IActionResult Index(string searchText = "", int page = 1)
		{
			int pageSize = 10;
			var Pager = Service.GetPager(searchText, page, pageSize);
			List<ProductAttributes> Attributes = Service.GetFiltered(searchText, page, pageSize);
			ViewBag.Pager = Pager;
			return View("Index", Attributes);
		}

		public IActionResult Add()
		{
			return View("Add");
		}

		[HttpPost]
        public IActionResult Add(ProductAttributes AttributeFromReq)
        {
            if (ModelState.IsValid == true)
            {
				Service.Create(AttributeFromReq);
				return RedirectToAction("Index");
			}
            return View("Add", AttributeFromReq);
        }
        
        public IActionResult Edit(int id)
        {
            ProductAttributes Attribute = Service.GetById(id);

			return View("Edit", Attribute);
        }
        
        [HttpPost]
        public IActionResult Edit(ProductAttributes AttributeFromReq)
        {
            var AttributeFromDb = Service.GetById(AttributeFromReq.Id);
            if (AttributeFromDb != null)
            {
				AttributeFromDb.Name = AttributeFromReq.Name;
				Service.Update(AttributeFromDb);
				return RedirectToAction("Index");
			}
			return View("Edit", AttributeFromReq);  
            }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }
		 
    }
}
