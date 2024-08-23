using Ecommerace.Models;
using Ecommerace.Services.Site;
using Ecommerace.ViewModels;
using Ecommerace.ViewModels.Site;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerace.Controllers
{
    public class SiteController : Controller
    {
        MVCECommeraceContext _context;
        ICategoriesService _categoriesService;

        public SiteController(ICategoriesService categoriesService , MVCECommeraceContext _context) {
            _categoriesService = categoriesService;

            this._context = _context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var categories = _categoriesService.GetCategoriesTree();
            ViewBag.NavbarViewModel = new NavbarViewModel { Categories = categories };

            base.OnActionExecuting(filterContext);
        }

        public IActionResult Index()
        {
            HomePageVM homePageVM = new HomePageVM();
            homePageVM.Categories = _context.Categories.Where(c => c.Parent_Id != null).Take(12).ToList();
            return View("Home" , homePageVM);
        }

        public IActionResult Cart()
        {

            return View("Cart");
        }

        public IActionResult Checkout()
        {
            return View("Checkout");
        }

        public IActionResult Detail()
        {
            return View("Detail");
        }

        public IActionResult Shop()
        {
            return View("Shop");
        }

        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}
