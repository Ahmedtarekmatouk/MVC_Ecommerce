using Ecommerace.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRole)
        {
            IdentityRole roleModel = new IdentityRole();
            roleModel.Name = newRole.RoleName;
            IdentityResult result = await roleManager.CreateAsync(roleModel);
            if (result.Succeeded)
            {
                return View("AddRole");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole", newRole);
        }
    }
}
