using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
   public class ImageDto
    {
        public int Id { get; set; }
        [ScriptIgnore]
        public string Name { get; set; }
        public  AttractionDto Attraction { get; set; }
        public string Base64Value { get; set; }

    }
}
