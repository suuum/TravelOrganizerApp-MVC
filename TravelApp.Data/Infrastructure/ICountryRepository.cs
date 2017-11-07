using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface ICountryRepository
    {
        void Create(Country entity);
        void Update(Country entity);
        void Delete(int id);
        Country GetById(int id);
        IEnumerable<Country> GetAll();
    }
}