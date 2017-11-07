using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("TripPlan")]
    public partial class TripPlan : Entity
    {
        public string PdfFile { get; set; }
        public string Transport { get; set; }
        public int HoursPerDay { get; set; }
        public string Directions { get; set; }
        public string MapUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual UserInfo User { get; set; }
        public Guid GuidId { get; set; }
    }
}
