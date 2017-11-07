using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("Favourite")]
    public class Favourite: Entity
    {
       
        
        public virtual Attraction Attraction { get; set; }
        
        public virtual UserInfo User { get; set; }
    }
}
