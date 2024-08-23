using Ecommerace.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Store.Controllers
{
    [Area("Store")]
    [StoreAuthorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
