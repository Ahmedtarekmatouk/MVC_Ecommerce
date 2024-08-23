using Ecommerace.Areas.Admin.ViewModels;

namespace Ecommerace.Services.Admin
{
    public interface IAdminService
    {
        List<UsersWithInfoViewModel> getUsers();
    }
}
