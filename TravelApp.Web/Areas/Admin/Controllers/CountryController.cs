using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        // GET: Admin/Country
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_countryService.GetCountries());
        }

        // GET: Admin/Country/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Country/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Country/Create
        [HttpPost]      
        public ActionResult Create(CountryDto countryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _countryService.CreateCountry(countryDto);
                    _countryService.SaveCountry();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Country/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(_countryService.GetCountry(id));
        }

        // POST: Admin/Country/Edit/5
        [HttpPost]
        public ActionResult Edit(CountryDto countryDto)
        {
            try
            {
                _countryService.EditCountry(countryDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                _countryService.DeleteCountry(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
