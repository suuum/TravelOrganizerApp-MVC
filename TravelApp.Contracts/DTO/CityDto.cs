using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ScriptIgnore]
        public IEnumerable<AttractionDto> Attraction { get; set; }
        [ScriptIgnore]
        public CountryDto Country { get; set; }

    }
}
