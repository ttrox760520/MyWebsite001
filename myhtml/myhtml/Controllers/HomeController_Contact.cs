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
    public partial class HomeController : BaseController
    {
        // GET: HomeController_Test
        public ActionResult Contact()
        {
            Session["Login"] = Session["Login"] != null ? Session["Login"].ToString() : "0";
            var db = new StudentDBEntities();
            List<Contact> dbInfo = db.Contact.ToList();
            var viewContactList = new List<ContactList>();
            foreach (Contact info in dbInfo)
            {
                var tmpInfo = new ContactList()
                {
                    Date = info.Date,
                    SeeDate = info.SeeDate,
                    ContactOne = info.ContactOne,
                    ContactTwo = info.ContactTwo,
                    ContactThree = info.ContactThree,
                    ContactFour = info.ContactFour,
                    ContactFive = info.ContactFive,
                    ContactSix = info.ContactSix,
                    ContactSeven = info.ContactSeven,
                    ContactEight = info.ContactEight,
                };
                viewContactList.Add(tmpInfo);
            }
            return View(viewContactList);
        }
    }
}