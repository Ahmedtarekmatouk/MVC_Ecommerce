using Microsoft.AspNetCore.Identity;

namespace Ecommerace.Seeders
{
    public class RolesSeeder
    {
        private RoleManager<IdentityRole>  _roleManager;
        public RolesSeeder(RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
        }

        public static async Task Run(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "SuperAdmin", "Admin", "Store" , "Client" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
