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
        #region List
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
        #endregion List

        #region Create
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contact CreateContact)
        {
            var db = new StudentDBEntities();
            List<Contact> dbInfo = db.Contact.ToList();
            var NewContact = new Contact();

            foreach (Contact theinfo in dbInfo)
            {
                if (CreateContact.Date.Equals(theinfo.Date))
                {
                    ViewData["Message"] = "已有此日之聯絡事項，請檢查是否日期輸入錯誤！";
                    return View();
                }
            }
            NewContact = CreateContact;
            db.Contact.Add(NewContact);
            db.SaveChanges();
            return RedirectToAction("Contact");

        }
        #endregion Create

        #region Edit
        public ActionResult EditContact(string id)
        {
            var db = new StudentDBEntities();
            List<Contact> dbInfo = db.Contact.ToList();

            var tmpInfo = new Contact()
            {
                Date = dbInfo[int.Parse(id)].Date,
                SeeDate = dbInfo[int.Parse(id)].SeeDate,
                ContactOne = dbInfo[int.Parse(id)].ContactOne,
                ContactTwo = dbInfo[int.Parse(id)].ContactTwo,
                ContactThree = dbInfo[int.Parse(id)].ContactThree,
                ContactFour = dbInfo[int.Parse(id)].ContactFour,
                ContactFive = dbInfo[int.Parse(id)].ContactFive,
                ContactSix = dbInfo[int.Parse(id)].ContactSix,
                ContactSeven = dbInfo[int.Parse(id)].ContactSeven,
                ContactEight = dbInfo[int.Parse(id)].ContactEight,
            };
            return View(tmpInfo);
            
        }
        [HttpPost]
        public ActionResult EditContact(string id , Contact EditContact)
        {
            var db = new StudentDBEntities();
            List<Contact> dbInfo = db.Contact.ToList();
            dbInfo[int.Parse(id)].Date = EditContact.Date;
            dbInfo[int.Parse(id)].SeeDate = EditContact.SeeDate;
            dbInfo[int.Parse(id)].ContactOne = EditContact.ContactOne;
            dbInfo[int.Parse(id)].ContactTwo = EditContact.ContactTwo;
            dbInfo[int.Parse(id)].ContactThree = EditContact.ContactThree;
            dbInfo[int.Parse(id)].ContactFour = EditContact.ContactFour;
            dbInfo[int.Parse(id)].ContactFive = EditContact.ContactFive;
            dbInfo[int.Parse(id)].ContactSix = EditContact.ContactSix;
            dbInfo[int.Parse(id)].ContactSeven = EditContact.ContactSeven;
            dbInfo[int.Parse(id)].ContactEight = EditContact.ContactEight;
            db.SaveChanges();
            ViewData["Message"] = "聯絡簿修改成功!";
            return RedirectToAction("Contact", new { msg = ViewData["Message"] });
        }
        #endregion Edit

        #region Delete
        public ActionResult DeleteContact(string id)
        {
            var db = new StudentDBEntities();
            List<Contact> dbInfo = db.Contact.ToList();
            db.Contact.Remove(dbInfo[int.Parse(id)]);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }
            #endregion Delete

    }
}