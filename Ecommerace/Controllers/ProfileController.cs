using Ecommerace.Models;
using Ecommerace.Services.Site;
using Ecommerace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Ecommerace.Controllers
{
    public class ProfileController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        SignInManager<ApplicationUser> signInManager;
        MVCECommeraceContext context;
        ICategoriesService _categoriesService;

        public ProfileController(UserManager<ApplicationUser> _UserManager, SignInManager<ApplicationUser> _signInManager, MVCECommeraceContext _context , ICategoriesService _categoriesService)
        {
            UserManager = _UserManager;
            signInManager = _signInManager;
            context = _context;
            this._categoriesService = _categoriesService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var categories = _categoriesService.GetCategoriesTree();
            ViewBag.NavbarViewModel = new NavbarViewModel { Categories = categories };

            base.OnActionExecuting(filterContext);
        }

        public IActionResult Index()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user=context.Users.FirstOrDefault(p=>p.Id==id);
            return View("Profile",user);
        }
        public async Task <IActionResult> SaveChange(ApplicationUser _user)
        {
            var id=  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = context.Users.FirstOrDefault(p => p.Id == id);
            if (user != null) 
            {
                user.UserName = _user.UserName;
                user.Email = _user.Email;
                user.PhoneNumber = _user.PhoneNumber;
                user.Addresses = _user.Addresses;
                context.Update(user);
                context.SaveChanges();
                await signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index"); 
            }
            return View("Error");
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View("Security");
        }
        [HttpPost]
        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel ResetVM)
        {
            if (ModelState.IsValid)
            {
                var CurnetUser =await UserManager.GetUserAsync(User);
                var CheckPassword = await UserManager.ChangePasswordAsync(CurnetUser, ResetVM.CurrentPassword, ResetVM.NewPassword);
                if (CheckPassword.Succeeded) 
                {
                    await signInManager.RefreshSignInAsync(CurnetUser);
                    return RedirectToAction("Index");
                }
                foreach(var item in CheckPassword.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Security");

        }
        public IActionResult MyOrder()
        {

            return View("ClientOrders");
        }

    }
}
