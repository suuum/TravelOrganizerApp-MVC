using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface IAttractionRepository
    {
        IEnumerable<Attraction> GetAll();
        IEnumerable<Attraction> GetAdminAll();       
        void Create(Attraction entity);
        void Edit(Attraction entity);
        void Delete(Attraction entity);
        void SetVisible(int id);
        Attraction GetById(int id);
        IEnumerable<Attraction> GetByCityId(int id);  
    }
}