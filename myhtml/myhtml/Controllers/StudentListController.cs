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
    public class StudentListController : BaseController
    {
        public ActionResult StudentList()
        {
            var db = new TestDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            var viewModelList = new List<StudentList>();
            foreach (Student info in dbInfo)
            {
                var tmpInfo = new StudentList()
                {
                    Id = info.Id,
                    座號 = info.座號,
                    姓名 = info.姓名,
                    暱稱 = info.暱稱,
                    電話 = info.電話,
                    地址 = info.地址,
                    緊急聯絡人 = info.緊急聯絡人,
                    緊急連絡人電話 = info.緊急連絡人電話,
                };
                viewModelList.Add(tmpInfo);
            }
            return View(viewModelList);
        }
        public ActionResult StudentList_Complete()
        {
            var db = new TestDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            var viewModelList = new List<StudentList>();
            foreach (Student info in dbInfo)
            {
                var tmpInfo = new StudentList()
                {
                    Id = info.Id,
                    座號 = info.座號,
                    姓名 = info.姓名,
                    暱稱 = info.暱稱,
                    電話 = info.電話,
                    地址 = info.地址,
                    緊急聯絡人 = info.緊急聯絡人,
                    緊急連絡人電話 = info.緊急連絡人電話,
                };
                viewModelList.Add(tmpInfo);
            }
            return View(viewModelList);
        }
    }
}