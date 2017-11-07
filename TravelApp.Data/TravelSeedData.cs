using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelApp.Entities.Model;
using Microsoft.AspNet.Identity;

namespace TravelApp.Data
{
    public class TravelSeedData :DropCreateDatabaseAlways<DataContext>{
       
            protected override void Seed(DataContext context)
            {
                GetCategories().ForEach(c => context.Attraction.Add(c));
               

                context.Commit();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DataContext()));


            if (!roleManager.RoleExists("ROLE NAME"))
            {
                var role = new IdentityRole();
                role.Name = "ROLE NAME";
                roleManager.Create(role);

            }

        }

            private static List<Attraction> GetCategories()
            {
                return new List<Attraction>
            {
                new Attraction {
                    Name = "Wilczy szaniec"
                },
                new Attraction {
                    Name = "Zamek Czocha"
                },
                new Attraction {
                    Name = "Big Ben"
                }
            };
            }


       
    }
}