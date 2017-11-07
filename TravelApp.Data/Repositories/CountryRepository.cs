using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public override IEnumerable<Country> GetAll()
        {
            return DbContext.Country.Include("Cities");
        }
        public override Country GetById(int id)
        {
           return DbContext.Country.Include("Cities").SingleOrDefault(x=>x.Id==id);
        }
        public void Create(Country country)
        {
            DbContext.Country.Add(country);
            DbContext.SaveChanges();
        }
        public override void Update(Country country)
        {
            Country updateCountry = DbContext.Country.Find(country.Id);
            updateCountry.Name = country.Name;
            DbContext.Entry(updateCountry).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Country deleteCountry = DbContext.Country.Find(id);
            DbContext.Country.Remove(deleteCountry);
            DbContext.SaveChanges();
        }

    }
}
