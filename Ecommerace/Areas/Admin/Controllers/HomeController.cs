using Ecommerace.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }
}
