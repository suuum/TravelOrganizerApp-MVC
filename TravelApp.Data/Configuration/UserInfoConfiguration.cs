using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class UserInfoConfiguration:EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            HasKey(e => e.Id);
            
            HasMany(e => e.Blogs)
                .WithRequired(e => e.User);
            HasMany(e => e.Comments)
                .WithRequired(e => e.User);
            HasMany(e => e.Favourites)
                .WithRequired(e => e.User);
            
            HasMany(e => e.TripPlans)
               .WithRequired(e => e.User);
            HasMany(e => e.Ranks)
               .WithRequired(e => e.User);


        }
    }
}