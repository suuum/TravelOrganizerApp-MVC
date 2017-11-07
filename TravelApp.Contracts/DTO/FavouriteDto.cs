using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
    public class FavouriteDto
    {
        public int Id { get; set; }
        [ScriptIgnore]
        public virtual AttractionDto Attraction { get; set; }
        [ScriptIgnore]
        public virtual UserDto UserDto { get; set; }
    }
}
