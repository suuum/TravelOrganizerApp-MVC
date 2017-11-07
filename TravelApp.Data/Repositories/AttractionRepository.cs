using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class AttractionRepository : RepositoryBase<Attraction>, IAttractionRepository
    {

        public AttractionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Create(Attraction entity)
        {
            entity.City = DbContext.City.Find(entity.City.Id);
            entity.Country = DbContext.Country.Find(entity.Country.Id);
            DbContext.Attraction.Add(entity);
            DbContext.SaveChanges();
        }

        public override void Delete(Attraction entity)
        {
            DbContext.Attraction.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Edit(Attraction entity)
        {
            Attraction updateAttraction = DbContext.Attraction.Find(entity.Id);
            updateAttraction.Name = entity.Name;
            updateAttraction.Description = entity.Description;
            updateAttraction.LongDescription = entity.LongDescription;
            updateAttraction.Photos = entity.Photos;
            updateAttraction.City = DbContext.City.Find(entity.City.Id);
            updateAttraction.Country = DbContext.Country.Find(entity.Country.Id);
            DbContext.Entry(updateAttraction).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public override IEnumerable<Attraction> GetAll()
        {
            return DbContext.Attraction.Include("City").Include("Country").Include("Ranks").Where(x => x.IsActive == true);
        }
        public IEnumerable<Attraction> GetAdminAll()
        {
            return DbContext.Attraction.Include("City").Include("Country").Include("Ranks");
        }


        public override Attraction GetById(int id)
        {
            DataContext data = new DataContext();
            return DbContext.Attraction.Include("City").Include("Country").Include("Ranks").Include("Comment").Single(x => x.Id == id);
        }

        public IEnumerable<Attraction> GetByCityId(int id)
        {
            DataContext data = new DataContext();
            return DbContext.Attraction.Include("City").Where(x=>x.City.Id==id);
        }
       public void SetVisible(int id)
        {

            Attraction updateAttraction = DbContext.Attraction.Find(id);
            if (updateAttraction.IsActive==true)
            {
                updateAttraction.IsActive = false;
            }
            else
            {
                updateAttraction.IsActive = true;
            }

            DbContext.Entry(updateAttraction).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();

        }

    }
}