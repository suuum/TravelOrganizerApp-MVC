using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("Comment")]
    public partial class Comment : Entity
    {
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Attraction Attraction { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual UserInfo User { get; set; }
    }
}
