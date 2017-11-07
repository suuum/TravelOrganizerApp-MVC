using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
    public class RankDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [ScriptIgnore]
        public UserDto User { get; set; }
        [ScriptIgnore]
        public AttractionDto Attraction { get; set; }
    }
}
