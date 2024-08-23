using Bogus;
using Ecommerace.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerace.Seeders
{
    public class StoresSeeder
    {
        public static async Task Run(UserManager<ApplicationUser> userManager)
        {
            var userFaker = new Faker<ApplicationUser>()
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
                .RuleFor(u => u.PhoneNumber, (f, u) => f.Phone.PhoneNumber())
                .RuleFor(u => u.EmailConfirmed, (f, u) => true);

            var password = "123456"; // Simple numeric password

            for (int i = 0; i < 25; i++)
            {
                var user = userFaker.Generate();

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Store");
                }
            }
        }
    }
}
