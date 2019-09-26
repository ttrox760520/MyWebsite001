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
        public ActionResult Index()
        {
            Session["Login"] = Session["Login"] != null ? Session["Login"].ToString() : "0";
            Session["UserName"] = Session["UserName"] != null ? Session["Login"].ToString() : null;

            //三元運算子      Session["Login"] = if判斷式 ? true : false
            /*
               if (Session["Login"] != null)
                   Session["Login"] = Session["Login"].ToString()
               else
                   Session["Login"] = "0"
             */
            IndexModel model1 = new IndexModel();
            
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
            Session["Login"] = Session["Login"] != null ? Session["Login"].ToString() : "0";
            if (Session["Login"].ToString() == "0")
                return View();
            else
                ViewData["Message"] = "帳號已經登入!";
            return View("Index");
        }
        [HttpPost]
        public ActionResult SignIn(Member SignInMember)
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();
            foreach (Member info in dbInfo)
            {
                if (info.Account == SignInMember.Account && info.Password == SignInMember.Password && info.RealMember == 1 && info.Account == "admin")
                {
                    ViewData["Message"] = info.UserName + "歡迎您回到本網站!";
                    Session["Login"] = "2";
                    Session["UserName"] = info.UserName;
                    return View("Index");
                }
                if (info.Account == SignInMember.Account && info.Password == SignInMember.Password && info.RealMember == 1)
                {
                    ViewData["Message"] = info.UserName + "歡迎您回到本網站!";
                    Session["Login"] = "1";
                    Session["UserName"] = info.UserName;
                    return View("Index");
                }
                if (info.Account == SignInMember.Account && info.Password == SignInMember.Password && info.RealMember == 0)
                {
                    ViewData["Message"] = "您的帳號尚未被驗證通過，暫時無法登入";
                    return View();
                }
                if (info.Account == SignInMember.Account && info.Password != SignInMember.Password)
                {
                    ViewData["Message"] = "您的密碼輸入錯誤！";
                    return View();
                }
                
            }
            ViewData["Message"] = "您的帳號輸入錯誤！";
            return View();
        }
        public ActionResult SignOut()
        {
            Session["Login"] = Session["Login"] != null ? Session["Login"].ToString() : "0";
            if (Session["Login"].ToString() == "0")
            {
                ViewData["Message"] = "帳號尚未登入!";
                return View("Index");
            }
            string SignOutMessage = Session["UserName"].ToString() + "已登出，歡迎您下次再度來訪。";
            Session["Login"] = "0";
            Session["UserName"] = null;
            ViewData["Message"] = SignOutMessage;
            return View("Index");
        }
        

    }
}