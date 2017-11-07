using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetCountries();
        CountryDto GetCountry(int id);
        IEnumerable<CityDto> GetCitiesByCountryId(int countryId);
        void CreateCountry(CountryDto country);
        void DeleteCountry(int id);
        void EditCountry(CountryDto country);
        void SaveCountry();
    }
}
