using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppSPA.Models;
using BlazorDapperSPA.Data;

namespace BlazorAppSPA.Service
{
    public class CityService : ICityService
    {
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