using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class TripPlanController : Controller
    {


        // GET: Admin/TripPlan
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/TripPlan/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/TripPlan/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TripPlan/Create
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

        // GET: Admin/TripPlan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/TripPlan/Edit/5
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

        // GET: Admin/TripPlan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/TripPlan/Delete/5
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
    }
}
