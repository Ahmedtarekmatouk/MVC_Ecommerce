using Ecommerace.Models;
using Ecommerace.Repositories.Clients;
using Ecommerace.Services.Clients;
using System.Collections.Generic;

namespace Ecommerace.Services;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _userRepository;

    public ClientsService(IClientsRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<ApplicationUser> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public ApplicationUser GetUserById(string id)
    {
        return _userRepository.GetById(id);
    }

    public void CreateUser(ApplicationUser user)
    {
        _userRepository.Create(user);
        _userRepository.Save();
    }

    public void UpdateUser(ApplicationUser user)
    {
        _userRepository.Update(user);
        _userRepository.Save();
    }

    public void DeleteUser(string id)
    {
        _userRepository.Delete(id);
        _userRepository.Save();
    }
}
