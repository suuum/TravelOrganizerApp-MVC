using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class TripPlanConfiguration:EntityTypeConfiguration<TripPlan>
    {
        public TripPlanConfiguration()
        {
        }
    }
}