using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TravelApp.Contracts.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CrateDate { get; set; }
        [ScriptIgnore]
        public AttractionDto Attraction { get; set; }
        public UserDto UserDto { get; set; }
        [ScriptIgnore]
        public BlogDto BlogDto { get; set; }
           
    }
}
