using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Contracts.DTO;

namespace TravelApp.Contracts.Interface
{
    public interface ITripPlanService
    {
        TripPlanDto GetTripPlanById(int id);
        void Create(TripPlanDto tripPlanDto);
        TripPlanDto GetByGuid(Guid guid);
    }
}
