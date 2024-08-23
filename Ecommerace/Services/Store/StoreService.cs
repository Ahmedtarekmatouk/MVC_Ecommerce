using Ecommerace.Models;
using Ecommerace.ViewModels.Store;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Services.Store
{
    public class StoreService:IStoreService
    {
        //Temporary untill Country , State , City CRUDS are done
        MVCECommeraceContext context;
        public StoreService()
        {

            context = new MVCECommeraceContext();
        }
        public RegisterViewModel GetRegisterViewModel()
        {
            List<Country> CountriesList = GetCountries();
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.CountriesList = CountriesList;
            return registerViewModel;
        }

        //Temp
        public List<Country> GetCountries()
        {
            return context.Country.ToList();
        }

        public List<State> GetStates(int id)
        {
            return context.State.Where(s => s.CountryId == id).ToList(); 
        }

        public List<City> GetCities(int id)
        {

            return context.City.Where(s => s.StateId == id).ToList();
        }

        public void AddAddress(UserAddress FullAddress)
        {
            context.UserAddress.Add(FullAddress);
            context.SaveChanges();

        }

        //public void AddAddressToUser(ApplicationUser user , UserAddress FullAddress)
        //{
        //    context.AspNetU;
        //    context.SaveChanges();
        //}
    }
}
