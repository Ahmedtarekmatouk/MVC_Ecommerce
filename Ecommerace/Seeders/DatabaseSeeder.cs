using Ecommerace.Models;
using Microsoft.AspNetCore.Identity;
using static System.Formats.Asn1.AsnWriter;

namespace Ecommerace.Seeders
{
    public class DatabaseSeeder
    {
        public static void Run(RoleManager<IdentityRole> roleManager , UserManager<ApplicationUser> userManager)
        {
           // RolesSeeder.Run(roleManager);
            //AdminsSeeder.Run(userManager);
            //StoresSeeder.Run(userManager);
           // ClientsSeeder.Run(userManager);
            CategoriesSeeder.Run();
           // CouponSeeder.Run();
        }
    }
}
