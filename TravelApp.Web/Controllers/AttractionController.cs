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
    public class AttractionController : Controller
    {
        IAttractionService _attractionService;
        ICountryService _countryService;
        ICommentService _commentService;
        IRankService _rankService;
        IFavouriteService _favouriteService;
        public AttractionController(IAttractionService attractionService, ICountryService countryService, ICommentService commentService, IRankService rankService, IFavouriteService favouriteService)
        {
            _attractionService = attractionService;
            _countryService = countryService;
            _commentService = commentService;
            _rankService = rankService;
            _favouriteService = favouriteService;

        }

        // GET: Attraction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Attraction/Details/5
        [Authorize(Roles = "User,Admin")]
        public ActionResult Details(int id)
        {
            ViewBag.ID = id;
            return View(_attractionService.GetAttraction(id));
        }

        // GET: Admin/Attraction/Create
        [Authorize(Roles = "Admin,User")]
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
        [Authorize(Roles = "User,Admin")]
        public ActionResult Create(AttractionDto attractionDto, int countryName, int cityName, List<HttpPostedFileBase> fileUpload)
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

        // GET: Attraction/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Attraction/Edit/5
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


        //api calls
        [HttpGet]
        public ActionResult GetCitiesByCountryId(int id)
        {
            IEnumerable<CityDto> city = _countryService.GetCitiesByCountryId(id);
            return Json(city, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllAttractions()
        {
            IEnumerable<AttractionDto> attractions = _attractionService.GetAttractions();

            foreach (AttractionDto attraction in attractions)
            {
                if (!string.IsNullOrWhiteSpace(attraction.Photos))
                {
                    attraction.Photos = attraction.Photos.Split(',')[0];
                }
            }
            return Json(attractions, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSingleAttraction(int id)
        {
            AttractionDto attraction = _attractionService.GetAttraction(id);
            attraction.PhotosArray = attraction.PhotosArray.Where(x => x != "").ToArray();
            for (int i = 0; i < attraction.PhotosArray.Length; i++)
            {
                attraction.PhotosArray[i] = "/Uploads/" + attraction.PhotosArray[i];
            }
            return Json(attraction, JsonRequestBehavior.AllowGet);
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
                _commentService.CreateAttractionComment(comment);
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

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public bool CheckIfIsFavourite(int id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(User.Identity.GetUserId()))
                {
                    return false;
                }
                else
                {
                    return _favouriteService.CheckIfIsFavourite(id, User.Identity.GetUserId());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public bool CreateFavourite(int id)
        {
            try
            {
                _favouriteService.CreateFavourite(new FavouriteDto()
                {
                    Attraction = new AttractionDto() { Id = id },
                    UserDto = new UserDto() { Id = User.Identity.GetUserId() }
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        public bool RemoveFavourite(int id)
        {
            try
            {
                _favouriteService.DeleteFavourite(new FavouriteDto()
                {
                    Attraction = new AttractionDto() { Id = id },
                    UserDto = new UserDto() { Id = User.Identity.GetUserId() }
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public bool CreateRank(RankDto rank)
        {
            try
            {
                rank.User = new UserDto()
                {
                    Id = User.Identity.GetUserId()
                };
                _rankService.CreateRank(rank);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public bool ChangeRank(RankDto rank)
        {
            try
            {
                rank.User = new UserDto()
                {
                    Id = User.Identity.GetUserId()
                };
                _rankService.EditRank(rank);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        public bool CheckIfIsRanked(int id)
        {
            try
            {
                return _rankService.CheckIfHaveRank(id, User.Identity.GetUserId());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult GetAttractionRank(int id)
        {
            try
            {
                return Json(_rankService.GetRankWithAttractionIdAndUserId(id, User.Identity.GetUserId()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
