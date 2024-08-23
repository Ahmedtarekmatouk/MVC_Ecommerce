using Ecommerace.Models;
using System.Collections.Generic;
using System.Linq;
using Ecommerace.Repositories.Clients;
using Ecommerace.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly MVCECommeraceContext _context;

    public ClientsRepository(MVCECommeraceContext context)
    {
        _context = context;
    }

    
    List<ApplicationUser> IRepository<ApplicationUser>.GetAll()
    {
        return _context.Users.ToList();
    }

    ApplicationUser IRepository<ApplicationUser>.GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id.ToString());
    }

    void IRepository<ApplicationUser>.Create(ApplicationUser user)
    {
        _context.Users.Add(user);
    }

    void IRepository<ApplicationUser>.Update(ApplicationUser user)
    {
        _context.Users.Update(user);
    }

    void IRepository<ApplicationUser>.Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id.ToString());
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }

    void IRepository<ApplicationUser>.Save()
    {
        _context.SaveChanges();
    }

    // Implementing IUserRepository methods
    public IEnumerable<ApplicationUser> GetAll()
    {
        return _context.Users.ToList();
    }

    public ApplicationUser GetById(string id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public void Create(ApplicationUser user)
    {
        _context.Users.Add(user);
    }

    public void Update(ApplicationUser user)
    {
        _context.Users.Update(user);
    }

    public void Delete(string id)
    {
        var user = GetById(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
