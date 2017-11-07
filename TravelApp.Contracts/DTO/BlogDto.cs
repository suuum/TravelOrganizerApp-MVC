using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TravelApp.Contracts.DTO
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public  UserDto User { get; set; }
        public string FileToBeUploaded { get; set; }
        public string BlogCoverPhoto { get; set; }
        public string ShortContent { get; set; }
        public ICollection<CommentDto> Comment { get; set; }
    }
}
