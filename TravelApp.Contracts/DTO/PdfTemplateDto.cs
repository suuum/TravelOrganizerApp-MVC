using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Contracts.DTO
{
    [Serializable]
    public class PdfTemplateDto
    {
        public List<AttractionDto> Attractions { get; set; }
        public int HoursPerDay { get; set; }
        public CityDto City { get; set; }
        public string DirectionForCity { get; set; }
        public string MapUrl { get; set; }
    }
}