using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.Data.Configuration
{
    public class IdentityRoleConfiguration:EntityTypeConfiguration<IdentityRole>
    {
        public IdentityRoleConfiguration()
        {
            HasKey<string>(r => r.Id);
        }
    }
}