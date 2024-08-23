using Ecommerace.Models;
using Ecommerace.Services.Attribute;
using Ecommerace.Services.AttributeOptions;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttributeOptionsController : Controller
    {
        private readonly IAttributeOptionsService Service;
        private readonly IAttributesService AService;

        public AttributeOptionsController(IAttributeOptionsService _service , IAttributesService Aservice)
        {
            Service = _service; 
            AService = Aservice;
        }
        public async Task<IActionResult> Index()
        {
            var model =await Service.GetAttributesWithAttributesOptions();
            return View(model);
        }

        public IActionResult Add()
        {
            List<ProductAttributes> AttributesList = AService.GetAll();
            ViewBag.AttributesList = AttributesList;
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(AttributesOptions AttributeOpFromReq)
        {
            bool flag = true;
			if (!(AttributeOpFromReq.AttributeId > 0))
			{
				ModelState.AddModelError("", "You Must Choose Attribute Name To Add This Option To It");
				flag = false;
			}
			if (ModelState.IsValid == true)
            {
                if (flag)
                {
                    AttributeOpFromReq.Attribute = AService.GetById(AttributeOpFromReq.AttributeId);
                    Service.Create(AttributeOpFromReq);
                    return RedirectToAction("Index");
                }
            }
			List<ProductAttributes> AttributesList = AService.GetAll();
			ViewBag.AttributesList = AttributesList;
			return View("Add", AttributeOpFromReq);
        }

		public IActionResult Edit(int id)
		{
			AttributesOptions AttributeOption = Service.GetById(id);
			List<ProductAttributes> AttributesList = AService.GetAll();
			ViewBag.AttributesList = AttributesList;

			return View("Edit", AttributeOption);
		}

		[HttpPost]
		public IActionResult Edit(AttributesOptions AttributeOpFromReq)
		{
			var AttributeOpFromDb = Service.GetById(AttributeOpFromReq.Id);
			if (AttributeOpFromDb != null)
			{
                if (ModelState.IsValid == true)
                {
                    if(AttributeOpFromDb.AttributeId!= AttributeOpFromReq.AttributeId)
                    {
						AttributeOpFromDb.Attribute = AService.GetById(AttributeOpFromReq.AttributeId);
						AttributeOpFromDb.AttributeId = AttributeOpFromReq.AttributeId;
					}
					AttributeOpFromDb.Value = AttributeOpFromReq.Value;
					Service.Update(AttributeOpFromDb);
                    return RedirectToAction("Index");
                }
			}
			List<ProductAttributes> AttributesList = AService.GetAll();
			ViewBag.AttributesList = AttributesList;
			return View("Edit", AttributeOpFromReq);
		}

		[HttpPost]
        public IActionResult Delete(int id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
