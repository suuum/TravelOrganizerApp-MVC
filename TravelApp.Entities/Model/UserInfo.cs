using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Entities.Model
{
    [Table("UserInfo")]
    public  class UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInfo()
        {
            Blogs = new HashSet<Blog>();
            Comments = new HashSet<Comment>();
            Favourites = new HashSet<Favourite>();
            Ranks = new HashSet<Rank>();
            TripPlans = new HashSet<TripPlan>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }       

        public DateTime BirthDate { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<Favourite> Favourites { get; set; }       
        public virtual ICollection<Rank> Ranks { get; set; }
        public virtual IdentityUserRole IdentityUserRole { get; set; }
        public virtual ICollection<TripPlan> TripPlans { get; set; }
    }
}
