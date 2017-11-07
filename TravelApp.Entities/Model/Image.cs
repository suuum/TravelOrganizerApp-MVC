using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entities.Model
{
    public class Image : Entity
    {
        public virtual Attraction Attraction{get;set;}
        public string Name { get; set; }
        [Column(TypeName = "text")]
        [MaxLength]
        public string Base64Value { get; set; }

    }
}
