using Ecommerace.Models;
using Ecommerace.Services;
using Ecommerace.Services.Site;
using Ecommerace.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
namespace Ecommerace.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> usermanager;
        SignInManager<ApplicationUser> signInManager;
        ICategoriesService _categoriesService;

        public AccountController(UserManager<ApplicationUser> _usermanager, SignInManager<ApplicationUser> _signInManager , ICategoriesService categoriesService)
        {
            usermanager = _usermanager;
            signInManager = _signInManager;
            _categoriesService = categoriesService;
        }
        public IActionResult Register()
        {
            return View("Register");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var categories = _categoriesService.GetCategoriesTree();
            ViewBag.NavbarViewModel = new NavbarViewModel { Categories = categories };

            base.OnActionExecuting(filterContext);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel RegisterVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = RegisterVM.UserName,
                    Email = RegisterVM.Email,
                    PasswordHash = RegisterVM.Password
                };
                IdentityResult result = await usermanager.CreateAsync(user, RegisterVM.Password);
                if (result.Succeeded)
                {
                    await usermanager.AddToRoleAsync(user,"Client");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("login","account", new { Area = "Home" });
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(RegisterVM);
        }
        public IActionResult Login()
        {
            return View("Login");
        }

     //  [Authorize(Roles ="Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(LoginViewModel LoginVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userDB = await usermanager.FindByNameAsync(LoginVM.UserName);
                if (userDB != null)
                {
                    bool found = await usermanager.CheckPasswordAsync(userDB, LoginVM.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(userDB, LoginVM.RememberMe);               
                        return RedirectToAction("Index", "Site", new { Area = "" });
                    }
                }
            }
            ModelState.AddModelError("", "Invalid UserName or Password");
            return View(LoginVM);
        }
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "account", new { Area = "" });
        }
    }
}
