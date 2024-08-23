using Microsoft.AspNetCore.Mvc;
using Ecommerace.Services;


namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;


        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            var products = productsService.GetAll();
            return View("AllProducts", products);
        }

        public IActionResult Details(int id)
        {
            var productDetails = productsService.GetById(id);
            return View(productDetails);
        }
        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}