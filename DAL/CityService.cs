using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppSPA.Models;
using BlazorAppSPA.Repository;

namespace BlazorAppSPA.DAL
{
    public class CityService : ICityService
    {
        public CityService()
        {
            
        }
        public Task<bool> CreateCity(City city)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCity(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditCity(int id, City city)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<City>> GetCities()
        {
            throw new System.NotImplementedException();
        }

        public Task<City> SingleCity(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}