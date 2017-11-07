using System.Data.Entity.ModelConfiguration;
using TravelApp.Entities.Model;

namespace TravelApp.Data.Configuration
{
    public class RankConfiguration:EntityTypeConfiguration<Rank>
    {
        public RankConfiguration()
        {
        }
    }
}