using Ecommerace.Models;

namespace Ecommerace.Repositories.Clients;

public interface IClientsRepository : IRepository<ApplicationUser>
{
    IEnumerable<ApplicationUser> GetAll();
    ApplicationUser GetById(string id);
    void Create(ApplicationUser user);
    void Update(ApplicationUser user);
    void Delete(string id);
    void Save();
}
