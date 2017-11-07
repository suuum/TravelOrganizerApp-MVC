using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("Attraction")]
    public class Attraction: Entity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Adress { get; set; }
        public string OpenHours { get; set; }
        public decimal Cost { get; set; }
        public bool IsActive { get; set; }
        public int AvrHoursTime { get; set; }
        public string Photos { get; set; }
        public string PhotosArray { get; set;}
        public virtual Country Country { get; set; }        
        public virtual City City { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Favourite> Favourites { get; set; }
        
        public virtual ICollection<Rank> Ranks { get; set; }
        
    }
}
