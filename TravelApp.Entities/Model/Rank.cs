using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("Rank")]
    public  class Rank : Entity
    {
        public int Number { get; set; }      
        public virtual UserInfo User { get; set; }
        public virtual Attraction Attraction { get; set; }
    }
}
