using Ecommerace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ecommerace.Views;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerace.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public IActionResult AddRoles()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task <IActionResult> AddRoles(RoleViewModel RoleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name=RoleVM.RoleName
                };
               IdentityResult result=await roleManager.CreateAsync(role);
            }
            return View("AddRole");
        }
    }
}
