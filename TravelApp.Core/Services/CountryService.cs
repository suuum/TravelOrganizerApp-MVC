using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;
using TravelApp.Data.Infrastructure;
using TravelApp.Data.Repositories;
using TravelApp.Entities.Model;

namespace TravelApp.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository,ICityRepository cityRepository)
        {
            this.unitOfWork = unitOfWork;
            this._countryRepository = countryRepository;
            this._cityRepository = cityRepository;
        }

        public IEnumerable<CountryDto> GetCountries()
        {
            return Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(_countryRepository.GetAll());
        }

        public CountryDto GetCountry(int id)
        {
            return Mapper.Map<Country,CountryDto>(_countryRepository.GetById(id));
        }

        public void CreateCountry(CountryDto countryDto)
        {
            Country country = new Country()
            {
                Name = countryDto.Name,             
            };

            _countryRepository.Create(country);
        }

        public void DeleteCountry(int id)
        {

            _countryRepository.Delete(id);

        }
        public void EditCountry(CountryDto country)
        {
            
            _countryRepository.Update(new Country()
            {Id=country.Id,
                Name=country.Name
            });
            
        }
        public void SaveCountry()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<CityDto> GetCitiesByCountryId(int countryId)
        {
            return Mapper.Map< IEnumerable<City>,IEnumerable<CityDto>>(_cityRepository.GetCitiesByCountryId(countryId));
        }
    }
}
