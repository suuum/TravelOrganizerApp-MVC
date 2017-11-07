using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class RankRepository : RepositoryBase<Rank>, IRankRepository
    {
        public RankRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Create(int number, int attractionId, string userId)
        {
            Rank entity = new Rank()
            {
                Number = number,
                User = DbContext.UserInfo.Single(x => x.Id == userId),
                Attraction = DbContext.Attraction.Single(x => x.Id == attractionId)
            };
            DbContext.Rank.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            DbContext.Rank.Remove(GetById(id));
            DbContext.SaveChanges();
        }

        public void Edit(int number, int attractionId, string userId)
        {
            Rank updatedEntity = DbContext.Rank.Single(x => x.User.Id == userId && x.Attraction.Id == attractionId);
            updatedEntity.Number = number;
            DbContext.Entry(updatedEntity).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public IEnumerable<Attraction> GetAllByUserId(string id)
        {
            return DbContext.Rank.Include("Attraction").Include("User").Where(x => x.User.Id == id).Select(x => x.Attraction);
        }

        public Rank GetById(int attractionId,string userId)
        {
            return DbContext.Rank.Include("Attraction").Include("User").SingleOrDefault(x => x.Attraction.Id == attractionId && x.User.Id == userId);
        }

    }
}
