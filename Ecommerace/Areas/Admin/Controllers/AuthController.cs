using Ecommerace.Areas.Admin.ViewModels;
using Ecommerace.Models;
using Ecommerace.Services.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthController : Controller
{

    private UserManager<ApplicationUser> userManager;
    private SignInManager<ApplicationUser> signInManager;
    private IAdminService _adminService;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAdminService adminService)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this._adminService = adminService;
    }
    public IActionResult Login()
    {
        return View("Login");
    }


    [AutoValidateAntiforgeryToken]
    [HttpPost]
    public async Task<IActionResult> Login(LoginNameAndPasswordViewModel userVM)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser userDb = await userManager.FindByNameAsync(userVM.UserName);
            if (userDb != null)
            {
                bool found = await userManager.CheckPasswordAsync(userDb, userVM.Password);
                if (found)
                {
                    bool isAdminOrSuperAdmin = await userManager.IsInRoleAsync(userDb, "Admin") || await userManager.IsInRoleAsync(userDb, "SuperAdmin");
                    if (isAdminOrSuperAdmin)
                    {
                        await signInManager.SignInAsync(userDb, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }  
                }
            }
            ModelState.AddModelError("", "Invalid Account");
        }

        return View();
    }
}
