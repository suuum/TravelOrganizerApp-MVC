using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<City> GetCities()
        {
            return DbContext.City.Include("Country");
        }
        public void CreateCity(City city)
        {
            city.Country = DbContext.Country.Single(x => x.Id == city.Country.Id);
            DbContext.City.Add(city);
            DbContext.SaveChanges();
        }
        public void Edit(City city)
        {
            city.Country = DbContext.Country.Single(x => x.Id == city.Country.Id);
            City updateCity = DbContext.City.Find(city.Id);
            updateCity.Name = city.Name;
            updateCity.Country = city.Country;
            DbContext.Entry(updateCity).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            City deleteCity = DbContext.City.Find(id);
            DbContext.City.Remove(deleteCity);
            DbContext.SaveChanges();
            
        }

        public IEnumerable<City> GetCitiesByCountryId(int countryId)
        {
            return DbContext.City.Where(x => x.Country.Id == countryId);
        }
    }
}
