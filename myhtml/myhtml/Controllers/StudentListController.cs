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
            var db = new StudentDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            var viewModelList = new List<StudentList>();
            foreach (Student info in dbInfo)
            {
                var tmpInfo = new StudentList()
                {
                    StudentID = info.StudentID,
                    ClassID = info.ClassID,
                    Name = info.Name,
                    Nickname = info.Nickname,
                    Phone = info.Phone,
                    Address = info.Address,
                    EmergencyContact = info.EmergencyContact,
                    EmergencyPhone = info.EmergencyPhone,
                };
                viewModelList.Add(tmpInfo);
            }
            return View(viewModelList);
        }
        public ActionResult StudentList_Complete()
        {
            var db = new StudentDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            var viewModelList = new List<StudentList>();
            foreach (Student info in dbInfo)
            {
                var tmpInfo = new StudentList()
                {
                    StudentID = info.StudentID,
                    ClassID = info.ClassID,
                    Name = info.Name,
                    Nickname = info.Nickname,
                    Phone = info.Phone,
                    Address = info.Address,
                    EmergencyContact = info.EmergencyContact,
                    EmergencyPhone = info.EmergencyPhone,
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
            var db = new StudentDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            var newuserinfo = new Student();

            foreach (Student theinfo in dbInfo)
            {
                if (info.StudentID.Equals(theinfo.StudentID))
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
                var db = new StudentDBEntities();
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
                var db = new StudentDBEntities();
                List<Student> dbInfo = db.Student.ToList();
                Student SelectStudent = new Student();
                SelectStudent.StudentID = dbInfo[int.Parse(num)].StudentID;
                SelectStudent.ClassID = dbInfo[int.Parse(num)].ClassID;
                SelectStudent.Name = dbInfo[int.Parse(num)].Name;
                SelectStudent.Nickname = dbInfo[int.Parse(num)].Nickname;
                SelectStudent.Phone = dbInfo[int.Parse(num)].Phone;
                SelectStudent.Address = dbInfo[int.Parse(num)].Address;
                SelectStudent.EmergencyContact = dbInfo[int.Parse(num)].EmergencyContact;
                SelectStudent.EmergencyPhone = dbInfo[int.Parse(num)].EmergencyPhone;

                return View(SelectStudent);
            }
            return View();
        }
        #endregion "Details"
    }



}