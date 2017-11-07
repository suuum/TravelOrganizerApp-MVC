using Microsoft.AspNet.Identity;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TravelApp.Contracts.DTO;
using TravelApp.Contracts.Interface;

namespace TravelApp.Web.Controllers
{
    public class TripPlanController : Controller
    {

        ITripPlanService _tripPlanService;
        ICountryService _countryService;
        IAttractionService _attractionService;
        public TripPlanController(ICountryService countryService, IAttractionService attractionSevice, ITripPlanService tripPlanService)
        {
            _countryService = countryService;
            _attractionService = attractionSevice;
            _tripPlanService = tripPlanService;
        }
        // GET: TripPlan
        [Authorize(Roles = "User,Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: TripPlan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AngularPostObject tripPlanObject)
        {
            TripPlanDto tripPlan = new TripPlanDto()
            {
                Directions = tripPlanObject.Directions,
                HoursPerDay = tripPlanObject.HoursPerDay,
                Transport = tripPlanObject.Transport,
                CreateDate = DateTime.Now,
                GuidId = Guid.NewGuid(),
                User = new UserDto() { Id = User.Identity.GetUserId() }
            };
            foreach (int item in tripPlanObject.Attractions)
            {
                tripPlan.PdfFile += item + ",";
            }

            _tripPlanService.Create(tripPlan);

            string id = _tripPlanService.GetByGuid(tripPlan.GuidId).GuidId.ToString();

            return Json(_tripPlanService.GetByGuid(tripPlan.GuidId).GuidId, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DownloadTripPlan(string id)
        {
            TripPlanDto tripPlan = _tripPlanService.GetByGuid(Guid.Parse(id));

            string[] attractionId = tripPlan.PdfFile.Split(',');

            List<AttractionDto> attractionList = new List<AttractionDto>();
            for (int i = 0; i < attractionId.Length - 1; i++)
            {
                attractionList.Add(_attractionService.GetAttraction(int.Parse(attractionId[i])));
            }

            foreach (var item in attractionList)
            {
               item.Adress= item.Adress.Replace(' ', '+');
            }

            // var MapUrl = "https://maps.googleapis.com/maps/api/staticmap?center=Brooklyn+Bridge,New+York&markers=,
            //NY &markers=color:blue%7Clabel:S%7CBrooklyn+Bridge,New+York,NY&markers=color:green%7Clabel:G%7C40.711614,-74.012318&
            //markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyD6bvtJUx9M1MP0FQ-eY26w_uMSxWgZhy0";

            string adressString = "https://maps.googleapis.com/maps/api/staticmap?zoom=13&size=1000x500&maptype=roadmap&center=" + attractionList[0].Adress;
            foreach (var item in attractionList)
            {
                adressString += "&markers=color:blue%7Clabel:S%7C" + item.Adress;
            }
            adressString += "&key=AIzaSyD6bvtJUx9M1MP0FQ-eY26w_uMSxWgZhy0";
            foreach (var item in attractionList)
            {
                item.Adress = item.Adress.Replace('+', ' ');
                item.Photos = "C:/Users/fum19_000/Source/Repos/TravelApp/TravelApp/TravelApp.Web/Uploads/" + item.Photos.Split(',')[0];
            }
            


           PdfTemplateDto listToPdfTemplate = new PdfTemplateDto()
            {
                Attractions=attractionList,
                DirectionForCity=tripPlan.Directions,
                HoursPerDay=tripPlan.HoursPerDay,
                MapUrl=adressString
            };
            listToPdfTemplate.DirectionForCity = listToPdfTemplate.DirectionForCity.Replace("Total Distance" ,"Całkowity dystans");
            WebRequest request = WebRequest.Create("http://fum1993-001-site1.btempurl.com/TripPlan/Template");
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(listToPdfTemplate.GetType());
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            JavaScriptSerializer jss = new JavaScriptSerializer();

            string yourdata = jss.Serialize(listToPdfTemplate);
            writer.Write(yourdata);
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(html);
            Response.Clear();
            Response.ContentType = "application/pdf; charset=utf-8";
            Response.BinaryWrite(pdfBytes);
            string fileName = string.Format("TwojPlanWycieczki_.pdf");
            Response.AddHeader("Content-Disposition",
               string.Format("attachment; filename={0}", fileName));
            Response.End();

            return Json(pdfBytes, JsonRequestBehavior.AllowGet);
        }

        // GET: TripPlan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TripPlan/Edit/5
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

        // GET: TripPlan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        public ActionResult Template(PdfTemplateDto listPdfTemplate)
        {
            return View(listPdfTemplate);
        }

        //public ActionResult GetPdf()
        //{

        //    var pdfBytes = Convert.FromBase64String(Base64Decode(_tripPlanService.GetTripPlanById(4).PdfFile));

        //    ;
        //    Response.ContentType = "application/pdf";
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.AddHeader("Content-Disposition", "Inline; filename=TEST.pdf");
        //    Response.BinaryWrite(pdfBytes);
        //    Response.Flush();
        //    Response.End();
        //    return RedirectToAction("Index");
        //}
        // POST: TripPlan/Delete/5
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
        public ActionResult GetAllCountries()
        {

            return Json(_countryService.GetCountries(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAttractionByCityId(int id)
        {

            return Json(_attractionService.GetAttractionByCityId(id), JsonRequestBehavior.AllowGet);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
