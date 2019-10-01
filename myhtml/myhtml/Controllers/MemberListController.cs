using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myhtml.Models.Home;
using BaseLibrary;
using myhtml.Models;
using static System.Net.Mime.MediaTypeNames;

namespace myhtml.Controllers
{
    public class MemberListController : BaseController
    {
        #region List
        public ActionResult MemberList()
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();
            var viewModelList = new List<MemberList>();
            foreach (Member info in dbInfo)
            {
                var tmpInfo = new MemberList()
                {
                    Account = info.Account,
                    Password = info.Password,
                    UserName = info.UserName,
                    Identity = info.Identity,
                    Memo = info.Memo,
                    RealMember = info.RealMember,
                };
                viewModelList.Add(tmpInfo);

            }
            return View(viewModelList);

        }
        #endregion List

        #region Create
        public ActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMember(Member NewMember)
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();
            var newmemberinfo = new Member();
            foreach (Member info in dbInfo)
            {
                if (NewMember.Account.Equals(info.Account))
                {
                    ViewData["Message"] = "此帳號已經註冊，請更換帳號";
                    return View("CreateMember");
                }
            }
            newmemberinfo = NewMember;
            db.Member.Add(newmemberinfo);
            db.SaveChanges();
            ViewData["Message"] = "帳號註冊成功!";
            return RedirectToAction("MemberList", new { msg = ViewData["Message"] });
        }

        #endregion Create

        #region Edit
        public ActionResult EditMember(string id)
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();

            var tmpInfo = new Member()
            {
                Account = dbInfo[int.Parse(id)].Account,
                Password = dbInfo[int.Parse(id)].Password,
                UserName = dbInfo[int.Parse(id)].UserName,
                Identity = dbInfo[int.Parse(id)].Identity,
                RealMember = dbInfo[int.Parse(id)].RealMember,
                Memo = dbInfo[int.Parse(id)].Memo,
            };
            return View(tmpInfo);
        }
        [HttpPost]
        public ActionResult EditMember(string id,Member info)
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();
            dbInfo[int.Parse(id)].Account = info.Account;
            dbInfo[int.Parse(id)].Password = info.Password;
            dbInfo[int.Parse(id)].UserName = info.UserName;
            dbInfo[int.Parse(id)].Identity = info.Identity;
            dbInfo[int.Parse(id)].RealMember = info.RealMember;
            dbInfo[int.Parse(id)].Memo = info.Memo;
            db.SaveChanges();
            ViewData["Message"] = "修改成功!";
            return RedirectToAction("MemberList", new { msg = ViewData["Message"] });
        }
        #endregion Edit

        #region Delete
        public ActionResult DeleteMember(string id)
        {
            var db = new StudentDBEntities();
            List<Member> dbInfo = db.Member.ToList();
            db.Member.Remove(dbInfo[int.Parse(id)]);
            db.SaveChanges();
            return RedirectToAction("MemberList");
        }
        #endregion Delete
    }

}
