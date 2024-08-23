using Ecommerace.Models;
using Microsoft.AspNetCore.Mvc;
using Ecommerace.Services;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkusController : Controller
    {
        //IService<Skus> skusService;
        //public SkusController(IService<Skus> skusService)
        //{
        //    this.skusService = skusService;
        //}

        //public IActionResult Index()
        //{
        //    var skus = skusService.GetAll();
        //    return View(skus);
        //}
        //public IActionResult Details(int id )
        //{
        //    var skusDetals= skusService.GetById(id);
        //    return View(skusDetals);
        //}
        //public IActionResult Create (Skus skus)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        skusService.Create(skus);
        //        return RedirectToAction("Index");
        //    }
        //    return View(skus);
        //}
        //public IActionResult Edit(Skus skus) 
        //{
        //    if (ModelState.IsValid)
        //    { 
        //        skusService.Update(skus);
        //        return RedirectToAction("Index");
        //    }
        //    return View(skus);
        //}
        //public IActionResult Delete(int id)
        //{
        //    skusService.Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}
