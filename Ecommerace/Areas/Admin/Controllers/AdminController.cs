using Ecommerace.Models;
using Ecommerace.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Ecommerace.Areas.Admin.ViewModels;

namespace Ecommerace.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IAdminService _adminService;

        public AdminController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager , IAdminService adminService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this._adminService = adminService;
        }

        //[HttpGet]//a
        //public IActionResult Register()
        //{
        //    return View("Register");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel newUserVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser newUser = new ApplicationUser
        //        {
        //            UserName = newUserVM.UserName,
        //            Balance = 0, 
                   
        //        };

        //        IdentityResult result = await userManager.CreateAsync(newUser, newUserVM.Password);

        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(newUser, "Admin");

        //            await signInManager.SignInAsync(newUser, isPersistent: false);

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //        }
        //    }

        //    return View("Register", newUserVM);
        //}


        public IActionResult Login()
        {
            return View();
        }

       
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginNameAndPasswordViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userDb = await userManager.FindByNameAsync(userVM.UserName);
                if (userDb == null)
                {
                    bool found = await userManager.CheckPasswordAsync(userDb, userVM.Password);
                    if (found) 
                    {
                        await signInManager.SignInAsync(userDb, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }

            return View();
        }

        public IActionResult getUsers()
        {
            List<UsersWithInfoViewModel> userVm = _adminService.getUsers();
            return View(userVm);
        }
        

    }
}
