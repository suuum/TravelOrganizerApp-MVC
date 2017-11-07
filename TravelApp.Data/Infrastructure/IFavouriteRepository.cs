using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface IFavouriteRepository
    {
        void Create(int attractionId, string userId);
        void Delete(int attractionId, string userId);
        Favourite GetById(int id);
        IEnumerable<Favourite> GetAll();
        IEnumerable<Attraction> GetAllByUserId(string id);
    }
}