
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("Blog")]
    public class Blog : Entity
    {
       
        
        public string Name { get; set; }
        [Column(TypeName = "text")]
        [MaxLength]
        public string Content { get; set; }
        [Column(TypeName = "text")]
        [MaxLength]
        public string BlogCoverPhoto { get; set; }
        public string ShortContent { get; set; }
        public virtual UserInfo User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }       
    }
}
