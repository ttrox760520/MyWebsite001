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


    }
   
}
