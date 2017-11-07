using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.Data.Configuration
{
    public class IdentityUserRoleConfiguration:EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(r => new { r.RoleId, r.UserId });       
        }
    }
}