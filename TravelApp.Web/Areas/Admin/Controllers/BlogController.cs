using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICommentService _commentService;
        public BlogController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }
        // GET: Admin/Blog
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_blogService.GetBlogs());
        }

        // GET: Admin/Blog/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Blog/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blog/Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(BlogDto blogDto , HttpPostedFileBase fileUpload)
        {
            try
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                fileUpload.SaveAs(path);
                blogDto.BlogCoverPhoto = fileName;

                _blogService.CreateBlog(blogDto);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Blog/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            BlogDto blogDto = _blogService.GetBlog(id);
            blogDto.FileToBeUploaded = blogDto.BlogCoverPhoto;
            return View(blogDto);
        }

        // POST: Admin/Blog/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BlogDto blogDto)
        {
            try
            {

                _blogService.EditBlog(blogDto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Blog/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _blogService.Delete(id);
            return View();
        }

        //api calls

      
    }
}
