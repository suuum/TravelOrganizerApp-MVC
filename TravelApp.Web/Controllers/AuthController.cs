using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelApp.Entities.Model;

namespace TravelApp.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
            public ActionResult LogIn()
            {
                return View();
            }
        

    }
}