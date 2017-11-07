using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface IRankRepository
    {
        void Create(int number,int attractionId,string userId);
        void Edit(int number, int attractionId, string userId);
        void Delete(int id);
        IEnumerable<Attraction> GetAllByUserId(string id);
        Rank GetById(int attractionId, string userId);
    }
}