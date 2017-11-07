using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.Data.Configuration
{
    public class IdentityUserLoginConfiguration:EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey<string>(l => l.UserId);
        }
    }
}