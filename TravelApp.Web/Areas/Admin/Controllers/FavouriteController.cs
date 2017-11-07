﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class FavouriteController : Controller
    {
        IFavouriteService _favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }
        // GET: Admin/Favourite
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Favourite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Favourite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Favourite/Create
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

        // GET: Admin/Favourite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Favourite/Edit/5
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

        // GET: Admin/Favourite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Favourite/Delete/5
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
