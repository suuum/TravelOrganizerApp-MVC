using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TravelApp.Entities.Model;
using TravelApp.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelApp.Data;
using TravelApp.Contracts.Interface;
using TravelApp.Controllers;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;        
        public ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }


        // GET: Admin/RoleAdmin
        public RoleController()
        {
        }
        public RoleController(ApplicationRoleManager roleManager)
        {
            _roleManager = roleManager;
          

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            DataContext context = new DataContext();
            return View(context.Roles.AsEnumerable());

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Initialize ApplicationRole instead of IdentityRole:
        //        var role = new ApplicationRole(roleViewModel.Name);
        //        var roleresult = await RoleManager.CreateAsync(role);
        //        if (!roleresult.Succeeded)
        //        {
        //            ModelState.AddModelError("", roleresult.Errors.First());
        //            return View();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //
        // POST: /Roles/Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(FormCollection collection)
        {
            var account = new AccountController();
            //account.UserManager.ro
            try
            {
                DataContext context = new DataContext();
                IdentityRole role = new IdentityRole();


                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"],
                });
                context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            DataContext context = new DataContext();
            var thisRole = context.Roles.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            DataContext context = new DataContext();
            var thisRole = context.Roles.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                DataContext context = new DataContext();
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles()
        {
            DataContext context = new DataContext();
            // prepopulat roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RoleAddToUser(string UserName, string RoleName)
        //{
        //    DataContext context = new DataContext();
        //    ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //    var account = new AccountController();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            DataContext context = new DataContext();
            ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                try
                {
                    var role = context.Roles.SingleOrDefault(m => m.Name == RoleName);
                    user.Roles.Add(new IdentityUserRole { RoleId = role.Id, UserId = user.Id });                  
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                ViewBag.ResultMessage = "Role created successfully !";

                // prepopulat roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }
            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                DataContext context = new DataContext();
                var user = context.Users.Single(x => x.UserName == UserName);
                if (user != null)
                {
                    var userRolesIds = user.Roles.Select(x => x.RoleId);
                    var userRolesNames = new List<IdentityRole>();
                    foreach (string item in userRolesIds)
                    {
                        userRolesNames.Add(context.Roles.Single(x => x.Id == item));
                    }
                    ViewBag.RolesForThisUser = userRolesNames.Select(x => x.Name);
                }
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRoleForUser(string UserName)
        {
            DataContext context = new DataContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (user.Roles.Count!=0)
            {
                user.Roles.Clear();
                context.SaveChanges();
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
    }
}