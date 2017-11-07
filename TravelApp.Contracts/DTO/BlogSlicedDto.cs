using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Contracts.DTO
{
   public class BlogSlicedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDto User { get; set; }
        public string FileToBeUploaded { get; set; }
        public string BlogCoverPhoto { get; set; }
        public string ShortContent { get; set; }
    }
}
