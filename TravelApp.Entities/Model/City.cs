using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("City")]
    public class City : Entity
    {
        public City()
        {
            Attraction = new HashSet<Attraction>();

        }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Attraction> Attraction { get; set; }
    }
}
