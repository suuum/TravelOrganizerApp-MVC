using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService,ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        // GET: Admin/City
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<CityDto> list = _cityService.GetCities().ToList();
            return View(_cityService.GetCities());
        }

        // GET: Admin/City/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/City/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
        new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.Country = list;
            return View();
        }

        // POST: Admin/City/Create
        [HttpPost]
        public ActionResult Create(CityDto city, string Country)
        {
            var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
        new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.Country = list;
            city.Country = new CountryDto() { Id = int.Parse(Country) };
            try
            {
                _cityService.CreateCity(city);
                _cityService.SaveCity();
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
        }

        // GET: Admin/City/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
                  new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();

            ViewBag.Country = list;
            
            return View(_cityService.GetCity(id));
        }

        // POST: Admin/City/Edit/5
        [HttpPost]
        public ActionResult Edit(CityDto city,string Country)
        {
            try
            {
                city.Country= new CountryDto() { Id = int.Parse(Country) };
                _cityService.EditCity(city);
                return RedirectToAction("Index");
            }
            catch
            {
                var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
                 new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Country = list;
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                _cityService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
