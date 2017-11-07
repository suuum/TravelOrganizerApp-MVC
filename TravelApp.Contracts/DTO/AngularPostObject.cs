using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Contracts.DTO
{
    public class AngularPostObject
    {
       public List<int> Attractions { get; set; }
        public string Transport { get; set; }
        public int HoursPerDay { get; set; }
        public string Directions { get; set; }
    }
}
