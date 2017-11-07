using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class CountryConfiguration:EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            HasMany(e => e.Attractions)
                   .WithRequired(e => e.Country);
            HasMany(e => e.Cities)
                    .WithRequired(x => x.Country);

        }
    }
}