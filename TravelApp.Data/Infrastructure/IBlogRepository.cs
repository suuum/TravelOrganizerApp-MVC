using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public interface IBlogRepository
    {
        void Create(Blog entity,string userId);
        void Edit(Blog entity);
        void Delete(int id);
        Blog GetById(int id);
        IEnumerable<Blog> GetAll();
    }
}