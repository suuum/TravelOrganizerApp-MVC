using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface ICityRepository
    {
        void CreateCity(City entity);
        void Edit(City entity);
        void Delete(int id);
        City GetById(int id);
        IEnumerable<City> GetCities();
        IEnumerable<City> GetCitiesByCountryId(int countryId);

    }
}