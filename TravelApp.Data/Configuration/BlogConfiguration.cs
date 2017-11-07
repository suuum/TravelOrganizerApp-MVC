using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class BlogConfiguration:EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {

        }
    }
}