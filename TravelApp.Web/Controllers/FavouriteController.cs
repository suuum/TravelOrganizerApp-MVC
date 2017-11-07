using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Controllers
{
    public class FavouriteController : Controller
    {
        IFavouriteService _favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        // GET: Favourite
        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Favourite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Favourite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favourite/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Favourite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Favourite/Edit/5
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

        // GET: Favourite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Favourite/Delete/5
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

        //api calls
        [HttpGet]
        public ActionResult GetAttractionsByUserId()
        {
            try
            {
                var attractions = _favouriteService.GetAllByUserId(User.Identity.GetUserId());
                foreach (AttractionDto attraction in attractions)
                {
                    if (!string.IsNullOrWhiteSpace(attraction.Photos))
                    {
                        attraction.Photos = attraction.Photos.Split(',')[0];
                    }
                }
                return Json(attractions, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
