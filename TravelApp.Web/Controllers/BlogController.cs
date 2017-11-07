using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Controllers
{
    public class BlogController : Controller
    {
        ICommentService _commentService;
        IBlogService _blogService;
        public BlogController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        // GET: Blog/Details/5
        [Authorize(Roles = "User,Admin")]
        public ActionResult Details(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        // GET: Blog/Create
        [Authorize(Roles = "User,Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "User,Admin")]
        public ActionResult Create(BlogDto blogDto, HttpPostedFileBase fileUpload)
        {
            try
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                fileUpload.SaveAs(path);
                blogDto.BlogCoverPhoto += fileName;

                blogDto.User = new UserDto() { Id = User.Identity.GetUserId() };
                _blogService.CreateBlog(blogDto);

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (NullReferenceException ex)
            {

                throw;
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetAllBlogs()
        {
            var jsonResult = Json(_blogService.GetBlogs(), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public ActionResult GetSingleBlog(int id)
        {
            var jsonResult = Json(_blogService.GetBlog(id), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult CreateComment(CommentDto comment)
        {
            try
            {
                comment.UserDto = new UserDto()
                {
                    Id = User.Identity.GetUserId()
                };
                _commentService.CreateBlogComment(comment);
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
    }
}
