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
            List<RunningMessage> RunMessage = db.RunningMessage.ToList();
            List<Contact> ContactList = db.Contact.ToList();
            string TheNewestDate = "0" ; //預設0的日期資料，以供比較日期資料
            var tmpInfo = new ContactList();
            foreach (Contact New in ContactList)
            {
                if (Int32.Parse(New.Date) > Int32.Parse(TheNewestDate)) //比較日期大小,找出數字最大(最新)的聯絡簿資料
                {
                    TheNewestDate = New.Date;
                    tmpInfo.Date = New.Date;
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
            tmpInfo.RunningMessage = RunMessage[0].Message;
            return View(tmpInfo);
        }
        [HttpPost]
        public ActionResult ChangeRunningMessage(ContactList NewMessage)
        {
            var db = new StudentDBEntities();
            List<RunningMessage> RunMessage = db.RunningMessage.ToList();
            RunMessage[0].Message = NewMessage.RunningMessage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AboutMe()
        {
            return View();
        }
        
        
        

    }
}