using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class FavouriteRepository : RepositoryBase<Favourite>, IFavouriteRepository
    {
        public FavouriteRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Create(int attractionId, string userId)
        {
            Favourite entity = new Favourite()
            {
                User = DbContext.UserInfo.Single(x => x.Id == userId),
                Attraction = DbContext.Attraction.Single(x => x.Id == attractionId)
            };
            DbContext.Favourite.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int attractionId, string userId)
        {
            try
            {
                Favourite entity = DbContext.Favourite.Single(x => x.Attraction.Id == attractionId && x.User.Id == userId);
                DbContext.Favourite.Remove(entity);
                DbContext.SaveChanges();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Attraction> GetAllByUserId(string id)
        {
            return DbContext.Favourite.Include("Attraction").Include("User").Where(x => x.User.Id == id).Select(x => x.Attraction);
        }

        public override Favourite GetById(int id)
        {
            return DbContext.Favourite.Single(x => x.Id == id);
        }
    }
}