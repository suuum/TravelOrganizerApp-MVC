using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class AttractionConfiguration : EntityTypeConfiguration<Attraction>
    {
        public AttractionConfiguration()
        {   //1 to many favourites comment
            HasMany(e => e.Comment)
                 .WithOptional(e => e.Attraction)
                 .WillCascadeOnDelete(false);
            //1 to many favourites
            HasMany(e => e.Favourites)
                .WithOptional(e => e.Attraction)
                .WillCascadeOnDelete(false);
            
        }
    }
}