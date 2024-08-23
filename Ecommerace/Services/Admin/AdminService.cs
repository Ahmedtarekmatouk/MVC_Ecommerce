using Ecommerace.Areas.Admin.ViewModels;
using Ecommerace.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerace.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public List<UsersWithInfoViewModel> getUsers()
        {
            var users = userManager.Users.ToList();

            var usersWithInfo = users.Select(user => new UsersWithInfoViewModel
            {
                id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            }).ToList();

            return usersWithInfo;
        }
    }
}
