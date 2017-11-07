using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelApp.Data;
using RTE;

namespace TravelApp.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {


            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DataContext()));



            //var role = new IdentityRole();
            //role.Name = "Admin";
            //roleManager.Create(role);
            //role = new IdentityRole();
            //role.Name = "User";
            //roleManager.Create(role);
            //Editor Editor1 = new Editor(System.Web.HttpContext.Current, "Editor1");
            //Editor1.LoadFormData("Type here...");
            //Editor1.MvcInit();
            //ViewBag.Editor = Editor1.MvcGetString();
            return View();
        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult About()
        {
            var userID = User.Identity.GetUserId();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}