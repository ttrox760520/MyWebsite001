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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRegister(Member NewMember)
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();
            var newmemberinfo = new Member();
            foreach (Member info in dbInfo)
            {
                if (NewMember.Account.Equals(info.Account))
                {
                    ViewData["Message"] = "此帳號已經註冊，請更換帳號";
                    return View("Register");
                }
            }
            newmemberinfo = NewMember;
            db.Member.Add(newmemberinfo);
            db.SaveChanges();
            ViewData["Message"] = "帳號已註冊成功，需經過帳號驗證方能使用";
            return RedirectToAction("Index", new { msg = ViewData["Message"] });

        }
        
    }
}