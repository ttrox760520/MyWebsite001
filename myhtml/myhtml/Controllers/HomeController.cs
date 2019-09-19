using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myhtml.Models.Home;
using BaseLibrary;
using myhtml.Models;


namespace myhtml.Controllers
{
    public partial class HomeController : BaseController  //partial可以用來切割過大的controller或model，原名稱後+_功能，以增加可讀性
    {
        public ActionResult Index()
        {
            IndexModel model1 = new IndexModel();
            model1.text = "測試~測試~";
            return View(model1);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }

    }
}