using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myhtml.Models.Home;
using BaseLibrary;
using myhtml.Models;

// Session["Login"]-----0=未登入 1=一般會員 2=管理員
namespace myhtml.Controllers
{
    public partial class HomeController : BaseController  //partial可以用來切割過大的controller或model，原名稱後+_功能，以增加可讀性
    {
        public ActionResult Index(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                ViewData["Message"] = msg;
            }
            Session["Login"] = Session["Login"] != null ? Session["Login"].ToString() : "0";
            Session["UserName"] = Session["UserName"] != null ? Session["UserName"].ToString() : null;
           
            var db = new StudentDBEntities();
            List<Contact> ContactList = db.Contact.ToList();
            string TheNewestDate = "0" ;
            var tmpInfo = new Contact();
            foreach (Contact New in ContactList)
            {
                if (Int32.Parse(New.Date) > Int32.Parse(TheNewestDate))
                {
                    TheNewestDate = New.Date;
                    tmpInfo.SeeDate = New.SeeDate;
                    tmpInfo.ContactOne = New.ContactOne;
                    tmpInfo.ContactTwo = New.ContactTwo;
                    tmpInfo.ContactThree = New.ContactThree;
                    tmpInfo.ContactFour = New.ContactFour;
                    tmpInfo.ContactFive = New.ContactFive;
                    tmpInfo.ContactSix = New.ContactSix;
                    tmpInfo.ContactSeven = New.ContactSeven;
                    tmpInfo.ContactEight = New.ContactEight;
                }
            }
            return View(tmpInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AboutMe()
        {
            return View();
        }
        
        
        

    }
}