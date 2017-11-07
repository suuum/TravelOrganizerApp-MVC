using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class CommentConfiguration:EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
        }
    }
}