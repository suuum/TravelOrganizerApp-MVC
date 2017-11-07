using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class CityConfiguration:EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            HasMany(e => e.Attraction)
                   .WithRequired(e => e.City);
           
        }
    }
}