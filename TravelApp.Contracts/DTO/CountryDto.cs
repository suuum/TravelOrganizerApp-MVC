using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
    public class CountryDto
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(50)]
        public string Name { get; set; }
        [ScriptIgnore]
        public IEnumerable<AttractionDto> Attractions { get; set; }
        
        public IEnumerable<CityDto> Cities { get; set; }
    }
}
