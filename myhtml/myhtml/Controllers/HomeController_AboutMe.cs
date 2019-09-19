using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myhtml.Models.Home;
using BaseLibrary;

namespace myhtml.Controllers
{
    public partial class HomeController : BaseController
    {
        // GET: HomeController_Test
        public ActionResult AboutMe()
        {
            return View();
        }
    }
}