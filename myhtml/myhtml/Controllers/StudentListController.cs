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
    
    public class StudentListController : BaseController
    {
        #region "List"
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
        #endregion "List"

        #region "Create"

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student info)
        {
            var db = new TestDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            var newuserinfo = new Student();

            foreach (Student theinfo in dbInfo)
            {
                if (info.Id.Equals(theinfo.Id))
                {
                    ViewData["Message"] = "學生學號重複，請修改學號！";
                    return View();
                }
            }
            newuserinfo = info;
            db.Student.Add(newuserinfo);
            db.SaveChanges();
            return RedirectToAction("StudentList");

        }
        #endregion "Create"

        #region "Delete"
        public ActionResult Delete(string num)
        {
            try
            {
                var db = new TestDBEntities();
                List<Student> dbInfo = db.Student.ToList();
                db.Student.Remove(dbInfo[int.Parse(num)]);
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            catch
            {
                ViewData["Message"] = "刪除失敗了唷!";
                return View("UserList");
            }
        }
        #endregion "Delete"

        #region "Details"
        public ActionResult Details(string num)
        {
            if (!string.IsNullOrEmpty(num))
            {
                var db = new TestDBEntities();
                List<Student> dbInfo = db.Student.ToList();
                Student SelectStudent = new Student();
                SelectStudent.Id = dbInfo[int.Parse(num)].Id;
                SelectStudent.座號 = dbInfo[int.Parse(num)].座號;
                SelectStudent.姓名 = dbInfo[int.Parse(num)].姓名;
                SelectStudent.暱稱 = dbInfo[int.Parse(num)].暱稱;
                SelectStudent.電話 = dbInfo[int.Parse(num)].電話;
                SelectStudent.地址 = dbInfo[int.Parse(num)].地址;
                SelectStudent.緊急聯絡人 = dbInfo[int.Parse(num)].緊急聯絡人;
                SelectStudent.緊急連絡人電話 = dbInfo[int.Parse(num)].緊急連絡人電話;

                return View(SelectStudent);
            }
            return View();
        }
        #endregion "Details"
    }



}