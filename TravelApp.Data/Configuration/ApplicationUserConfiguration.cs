    using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class ApplicationUserConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
       {
            HasOptional(s => s.UserInfo)
             .WithRequired(ad => ad.ApplicationUser);
        }
    }
}