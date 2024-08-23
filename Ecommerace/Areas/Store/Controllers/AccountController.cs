using Ecommerace.Models;
using Ecommerace.Services.Store;
using Ecommerace.ViewModels.Store;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Ecommerace.Areas.Store.Controllers
{
    [Area("Store")]
    public class AccountController : Controller
    {
        IStoreService Service;
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;

        public AccountController(IStoreService service , UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) 
        {
            Service = service;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            RegisterViewModel RegisterViewModel = Service.GetRegisterViewModel();
            return View("Register",RegisterViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel storeFromReq)
        {
            var flag = true;
            if (storeFromReq.CountryId == 0 || storeFromReq.StateId == 0 || storeFromReq.CityId == 0)
            {
                ModelState.AddModelError("", "Country , State , City Are Required");
                flag = false;
            }
            if (flag && ModelState.IsValid)
            {
                
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = storeFromReq.UserName,
                    Email = storeFromReq.Email,
                    PasswordHash = storeFromReq.Password,
                    Balance = 0
                };
                IdentityResult result = await userManager.CreateAsync(user, storeFromReq.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Store");
                    await signInManager.SignInAsync(user, false);


                    UserAddress userAddress = new UserAddress()
                    {
                        UserId = user.Id,
                        CountryId = storeFromReq.CountryId,
                        StateId = storeFromReq.StateId,
                        CityId = storeFromReq.CityId,
                        Address = storeFromReq.Address,
                    };
                    //Add Address in UserAddress Table
                    Service.AddAddress(userAddress);
                    //Add Adress to ICollection<UserAddress> in ApplicationUser
                    user.Addresses.Add(userAddress);
                    return RedirectToAction("Index", "Home", new { Area = "Store" });
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            storeFromReq.CountriesList = Service.GetCountries();
            return View("Register", storeFromReq);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel storeFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userDB = await userManager.FindByNameAsync(storeFromReq.UserName);
                if (userDB != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userDB,storeFromReq.Password);
                    if (found)
                    {
                        bool isStoreUser = await userManager.IsInRoleAsync(userDB, "Store");
                        if (isStoreUser)
                        {
                            await signInManager.SignInAsync(userDB, storeFromReq.RememberMe);
                            return RedirectToAction("Index", "Home", new { Area = "Store" });
                        }
                        
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            else 
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
            }
            return View("LogIn", storeFromReq);

        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account", new { Area = "Store" });
        }

        //Temp 
        public IActionResult GetStates(int id)
        {
            return Json(Service.GetStates(id));
        }

        public IActionResult GetCities(int id)
        {
            return Json(Service.GetCities(id));
        }

    }
}
