using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using TravelApp.Entities.Model;
using TravelApp.Web.Models;
using TravelApp.Data;
using TravelApp.Data.Infrastructure;
using TravelApp.Contracts.DTO;
using AutoMapper;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _userRepository;
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public UserController(ApplicationSignInManager signInManager, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            SignInManager = signInManager;
        }

        // GET: Admin/UserAdmin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            DataContext db = new DataContext();
            var roles = db.Roles;
            var usersinfo = db.UserInfo.Include("IdentityUserRole");

            return View(usersinfo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email
                };

                // Add the Address Info:
                user.UserInfo.Name = userViewModel.Name;
                user.UserInfo.LastName = userViewModel.LastName;
                user.UserInfo.BirthDate = userViewModel.BirthDate;
                return View();
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            DataContext db = new DataContext();
           var userToEdit = Mapper.Map<UserInfo, UserDto>(db.UserInfo.Single(x => x.Id == id));
            userToEdit.Email = db.Users.Single(x => x.Id == id).Email;
            return View(userToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(UserDto editUser)
        {
            if (ModelState.IsValid)
            {
                DataContext db = new DataContext();
                ApplicationUser applicationUser = db.Users.Single(x=>x.Id == editUser.Id);
                UserInfo user = db.UserInfo.Single(x => x.Id == editUser.Id);
                user.Name = editUser.Name;
                user.LastName = editUser.LastName;
                user.BirthDate = editUser.BirthDate;
                applicationUser.Email = editUser.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }
        [HttpGet]        
        public ActionResult BlockUser(string id)
        {
            DataContext db = new DataContext();
            ApplicationUser updatedUser= db.Users.Find(id);
            updatedUser.LockoutEnabled = true;
            updatedUser.LockoutEndDateUtc = DateTime.MaxValue;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UnBlockUser(string id)
        {
            DataContext db = new DataContext();
            ApplicationUser updatedUser = db.Users.Find(id);
            updatedUser.LockoutEnabled = false;
            updatedUser.LockoutEndDateUtc = null;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}