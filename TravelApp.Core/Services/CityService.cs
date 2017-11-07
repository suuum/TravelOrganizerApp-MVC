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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICityRepository _cityRepository;
        public CityService(IUnitOfWork unitOfWork, ICityRepository cityRepository)
        {
            this.unitOfWork = unitOfWork;
            this._cityRepository = cityRepository;
        }

        public IEnumerable<CityDto> GetCities()
        {
            List<City> list = _cityRepository.GetCities().ToList();


            List<CityDto> listdto = Mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(_cityRepository.GetCities()).ToList();
            return Mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(_cityRepository.GetCities());
        }

        public CityDto GetCity(int id)
        {
           return Mapper.Map<City,CityDto>(_cityRepository.GetById(id));
        }
        public void EditCity(CityDto cityDto)
        {
            
            _cityRepository.Edit(new City()
            {
                Id= cityDto.Id,
                Name= cityDto.Name,
                Country = new Country() { Id = cityDto.Country.Id }
            });
           // unitOfWork.Commit();

        }

        public void CreateCity(CityDto cityDto)
        {
            City city = new City()
            {
                Name = cityDto.Name,
                Attraction = Mapper.Map<IEnumerable<AttractionDto>, ICollection<Attraction>>(cityDto.Attraction),
                Country= new Country() {Id= cityDto.Country.Id }
            };
            
            _cityRepository.CreateCity(city);
        }
        public void Delete(int id)
        {
            _cityRepository.Delete(id);

        }
        
        public void SaveCity()
        {
            unitOfWork.Commit();
        }
    }
}
