using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TempController : Controller
    {
        
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Form()
        {
            return View("Forms");
        }
    }
}
