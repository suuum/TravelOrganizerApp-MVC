using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("Country")]
    public class Country : Entity
    {
        public Country()
        {
            Attractions = new HashSet<Attraction>();
        }  
        public string Name { get; set; }
        
        public virtual ICollection<Attraction> Attractions { get; set; }
        
        public virtual ICollection<City> Cities { get; set; }
    }
}
