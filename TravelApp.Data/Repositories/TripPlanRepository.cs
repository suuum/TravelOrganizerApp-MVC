using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Data.Infrastructure;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Repositories
{
    public class TripPlanRepository : RepositoryBase<TripPlan>, ITripRepository
    {
        public TripPlanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Create(TripPlan entity,string userId)
        {
            try
            {
                entity.User = DbContext.UserInfo.Single(x=>x.Id==userId);
                DbContext.TripPlan.Add(entity);
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public void Delete(int id)
        {
            TripPlan deleteTripPlan = DbContext.TripPlan.Find(id);
            DbContext.TripPlan.Remove(deleteTripPlan);
            DbContext.SaveChanges();
        }

        public void Edit(TripPlan entity)
        {
            TripPlan updateTripPlan = DbContext.TripPlan.Find(entity.Id);
            updateTripPlan.PdfFile = entity.PdfFile;
            updateTripPlan.User = entity.User;
            DbContext.Entry(updateTripPlan).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        public override TripPlan GetById(int id)
        {
            return DbContext.TripPlan.Single(x => x.Id == id);
        }
        public override IEnumerable<TripPlan> GetAll()
        {
            return DbContext.TripPlan;
        }

        public TripPlan GetIdByGuid(Guid guid)
        {
            return DbContext.TripPlan.Single(x => x.GuidId == guid);
        }
        public IEnumerable<TripPlan> GetByUserId(string id)
        {
            return DbContext.TripPlan.Where(x => x.User.Id == id);

        }
    }
}
