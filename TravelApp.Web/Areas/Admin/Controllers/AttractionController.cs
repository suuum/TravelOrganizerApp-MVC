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
    public class AttractionController : Controller
    {
        IAttractionService _attractionService;
        ICountryService _countryService;
        public AttractionController(IAttractionService attractionSevice,ICountryService countryService)
        {
            _attractionService = attractionSevice;
            _countryService = countryService;
        }
        [HttpGet]
        public ActionResult GetAllAttraction()
        {
            return Json(_attractionService.GetAttractions(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SetVisibleAttraction(int id)
        {
            _attractionService.SetAttractionVisible(id);
            return RedirectToAction("Index");
        }

        // GET: Admin/Attraction
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_attractionService.GetAdminAttractions());
        }

        // GET: Admin/Attraction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Attraction/Create
        public ActionResult Create()
        {
            var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
                 new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.countryName = list;
            var listCity = new List<SelectListItem>() { 
                  new SelectListItem { Value = "Select", Text = "Select" }};          
            ViewBag.cityName = listCity;
            return View();
        }

        // POST: Admin/Attraction/Create
        [HttpPost]
        public ActionResult Create(AttractionDto attractionDto,int countryName,int cityName, List<HttpPostedFileBase> fileUpload)
        {

            try
            {
                foreach (HttpPostedFileBase item in fileUpload)
                {
                    var fileName = Path.GetFileName(item.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    item.SaveAs(path);
                    attractionDto.Photos += fileName + ",";
                }

                var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
                 new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
                ViewBag.countryName = list;
                list.Clear();
                var listCity = new List<SelectListItem>() {
                  new SelectListItem { Value = "Select", Text = "Select" }};
                ViewBag.cityName = listCity;
                attractionDto.City = new CityDto()
                {
                    Id = cityName
                };
                attractionDto.Country = new CountryDto()
                {
                    Id = countryName
                };
                _attractionService.CreateAttraction(attractionDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Attraction/Edit/5
        public ActionResult Edit(int id)
        {
            AttractionDto attraction = _attractionService.GetAttraction(id);
            var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
                 new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.countryName = list;
            var listCity = new List<SelectListItem>() {
                  new SelectListItem { Value = "Select", Text = "Select" }};
            ViewBag.cityName = listCity;
            
            return View(attraction);
        }

        // POST: Admin/Attraction/Edit/5
        [HttpPost]
        public ActionResult Edit(AttractionDto attractionDto, int countryName, int cityName)
        {
            try
            {

                var list = _countryService.GetCountries().OrderBy(r => r.Name).ToList().Select(rr =>
                 new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
                ViewBag.countryName = list;
                var listCity = new List<SelectListItem>() {
                  new SelectListItem { Value = "Select", Text = "Select" }};
                ViewBag.cityName = listCity;
                attractionDto.City = new CityDto()
                {
                    Id = cityName
                };
                attractionDto.Country = new CountryDto()
                {
                    Id = countryName
                };
                _attractionService.EditAttraction(attractionDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _attractionService.DeleteAttraction(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult GetCitiesByCountryId(int id)
        {
            IEnumerable<CityDto> city = _countryService.GetCitiesByCountryId(id);
            return Json(city, JsonRequestBehavior.AllowGet);
        }
    }
}
