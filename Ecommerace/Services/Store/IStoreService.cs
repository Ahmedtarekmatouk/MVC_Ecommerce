using Ecommerace.Models;
using Ecommerace.ViewModels.Store;
namespace Ecommerace.Services.Store
{
    public interface IStoreService:IService
    {
        public RegisterViewModel GetRegisterViewModel();

        //Temp
        public List<Country> GetCountries();
        public List<State> GetStates(int id);

        public List<City> GetCities(int id);

        public void AddAddress(UserAddress FullAddress);
    }
}
