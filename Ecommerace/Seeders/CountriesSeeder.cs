using Ecommerace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Ecommerace.Seeders;

public class CountriesSeeder
{
    HttpClient _httpClient;
    MVCECommeraceContext _context;
    public CountriesSeeder() {
        _httpClient = new HttpClient();
        _context = new MVCECommeraceContext();
    }

    public void Run()
    {

        StoreCountryData("Egypt");

    }


    public async Task StoreCountryData(string countryName)
    {
        // Fetch states from the first API
        var statesWithCities = await GetStatesFromApi(countryName);

        // Create the country
        var country = new Country
        {
            Name = countryName
        };

        // Add the country to the context
        _context.Country.Add(country);
        await _context.SaveChangesAsync();

        foreach (var state in statesWithCities)
        {
            // Create each state
            var stateEntity = new State
            {
                Name = state.Name,
                CountryId = country.Id
            };
            _context.State.Add(stateEntity);
            await _context.SaveChangesAsync();

            // Fetch cities for each state
            var cities = await GetCitiesFromApi(countryName, state.Name);

            foreach (var city in cities)
            {
                // Create each city
                var cityEntity = new City
                {
                    Name = city,
                    StateId = stateEntity.Id
                };
                _context.City.Add(cityEntity);
            }

            // Save cities for the state
            await _context.SaveChangesAsync();
        }
    }

    private async Task<List<StateWithCities>> GetStatesFromApi(string countryName)
    {
        var requestData = new
        {
            country = countryName
        };

        var requestContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://countriesnow.space/api/v0.1/countries/states", requestContent);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ApiResponse>(content);
            return data.Data.States.Select(s => new StateWithCities { Name = s.Name }).ToList();
        }

        return new List<StateWithCities>();
    }

    private async Task<List<string>> GetCitiesFromApi(string countryName, string stateName)
    {
        var requestData = new
        {
            country = countryName,
            state = stateName
        };

        var requestContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://countriesnow.space/api/v0.1/countries/state/cities", requestContent);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CityResponse>(content);
            return data.Data;
        }

        return new List<string>();
    }

}
public class ApiResponse
{
    public bool Error { get; set; }
    public string Msg { get; set; }
    public CountryData Data { get; set; }
}

public class CountryData
{
    public string Name { get; set; }
    public string Iso3 { get; set; }
    public List<StateData> States { get; set; }
}

public class StateData
{
    public string Name { get; set; }
    public string StateCode { get; set; }
}

public class CityResponse
{
    public bool Error { get; set; }
    public string Msg { get; set; }
    public List<string> Data { get; set; }
}

public class StateWithCities
{
    public string Name { get; set; }
}