using Ecommerace.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerace.Seeders
{
    public class AdminsSeeder
    {
        public async static Task Run(UserManager<ApplicationUser> userManager)
        {

            var superAdmin = new ApplicationUser { UserName = "SuperAdmin", Email = "SuperAdmin@mail.com" };
            var res =  await userManager.CreateAsync(superAdmin , "123456");
            await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");

            var admin = new ApplicationUser { UserName = "admin", Email = "admin@admin.com",  };
            await userManager.CreateAsync(admin , "123456");
            await userManager.AddToRoleAsync(admin, "Admin");

        }
    }
}
    