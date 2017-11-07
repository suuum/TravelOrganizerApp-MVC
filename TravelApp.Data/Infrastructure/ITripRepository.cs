using System;
using System.Collections.Generic;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Infrastructure
{
    public interface ITripRepository
    {
        void Create(TripPlan entity,string userId);
        void Edit(TripPlan entity);
        void Delete(int id);
        TripPlan GetById(int id);
        IEnumerable<TripPlan> GetAll();
        TripPlan GetIdByGuid(Guid guid);
        IEnumerable<TripPlan> GetByUserId(string id);
    }
}