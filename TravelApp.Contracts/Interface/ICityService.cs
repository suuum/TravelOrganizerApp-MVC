using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface ICityService
    {
        IEnumerable<CityDto> GetCities();
        CityDto GetCity(int id);
        void CreateCity(CityDto City);
        void EditCity(CityDto City);
        void Delete(int id);
        void SaveCity();
    }
}
