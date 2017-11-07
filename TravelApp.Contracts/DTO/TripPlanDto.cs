using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Contracts.DTO
{
    public class TripPlanDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string PdfFile { get; set; }
        public string Transport { get; set; }
        public int HoursPerDay { get; set; }
        public string Directions { get; set; }
        public string MapUrl { get; set; }
        public UserDto User { get; set; }
        public Guid GuidId { get; set; }
    }
}
