using Ecommerace.Models;
using System.Collections.Generic;

namespace Ecommerace.Services.Clients;

public interface IClientsService : IService
{
    IEnumerable<ApplicationUser> GetAllUsers();
    ApplicationUser GetUserById(string id);
    void CreateUser(ApplicationUser user);
    void UpdateUser(ApplicationUser user);
    void DeleteUser(string id);
}
