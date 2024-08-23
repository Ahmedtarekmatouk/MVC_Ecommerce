using Ecommerace.Models;

namespace Ecommerace.Repositories
{
    public interface IUsersRepository : IRepository<ApplicationUser>
    {
        List<ApplicationUser> GetUserViaRole(string roleName);  
    }
}
