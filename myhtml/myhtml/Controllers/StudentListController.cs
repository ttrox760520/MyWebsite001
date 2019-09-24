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

        #region "Edit"

        public ActionResult Edit(string id)
        {
            var db = new StudentDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            
            var tmpInfo = new Student()
            {
                StudentID = dbInfo[int.Parse(id)].StudentID,
                ClassID = dbInfo[int.Parse(id)].ClassID,
                Name = dbInfo[int.Parse(id)].Name,
                Nickname = dbInfo[int.Parse(id)].Nickname,
                Phone = dbInfo[int.Parse(id)].Phone,
                Address = dbInfo[int.Parse(id)].Address,
                EmergencyContact = dbInfo[int.Parse(id)].EmergencyContact,
                EmergencyPhone = dbInfo[int.Parse(id)].EmergencyPhone,
            };
            return View(tmpInfo);
        }
        [HttpPost]
        public ActionResult Edit(string id, Student info)
        {
            var db = new StudentDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            try
            {
                dbInfo[int.Parse(id)].StudentID = info.StudentID;
                dbInfo[int.Parse(id)].ClassID = info.ClassID;
                dbInfo[int.Parse(id)].Name = info.Name;
                dbInfo[int.Parse(id)].Nickname = info.Nickname;
                dbInfo[int.Parse(id)].Phone = info.Phone;
                dbInfo[int.Parse(id)].Address = info.Address;
                dbInfo[int.Parse(id)].EmergencyContact = info.EmergencyContact;
                dbInfo[int.Parse(id)].EmergencyPhone = info.EmergencyPhone;
                db.SaveChanges();
                return RedirectToAction("StudentList_Complete");
            }
            catch
            {
                ViewData["Message"] = "修改出錯了唷!";
                return View("Edit");
            }
        }

        #endregion "Edit"

        #region "Delete"
        public ActionResult Delete(string id)
        {
            try
            {
                var db = new StudentDBEntities();
                List<Student> dbInfo = db.Student.ToList();
                db.Student.Remove(dbInfo[int.Parse(id)]);
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
        public ActionResult Details(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var db = new StudentDBEntities();
                List<Student> dbInfo = db.Student.ToList();
                Student SelectStudent = new Student();

                SelectStudent.StudentID = dbInfo[int.Parse(id)].StudentID;
                SelectStudent.ClassID = dbInfo[int.Parse(id)].ClassID;
                SelectStudent.Name = dbInfo[int.Parse(id)].Name;
                SelectStudent.Nickname = dbInfo[int.Parse(id)].Nickname;
                SelectStudent.Phone = dbInfo[int.Parse(id)].Phone;
                SelectStudent.Address = dbInfo[int.Parse(id)].Address;
                SelectStudent.EmergencyContact = dbInfo[int.Parse(id)].EmergencyContact;
                SelectStudent.EmergencyPhone = dbInfo[int.Parse(id)].EmergencyPhone;

                return View(SelectStudent);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Details(string id, Student info)
        {
            var db = new StudentDBEntities();
            List<Student> dbInfo = db.Student.ToList();
            try
            {
                dbInfo[int.Parse(id)].StudentID = info.StudentID;
                dbInfo[int.Parse(id)].ClassID = info.ClassID;
                dbInfo[int.Parse(id)].Name = info.Name;
                dbInfo[int.Parse(id)].Nickname = info.Nickname;
                dbInfo[int.Parse(id)].Phone = info.Phone;
                dbInfo[int.Parse(id)].Address= info.Address;
                dbInfo[int.Parse(id)].EmergencyContact = info.EmergencyContact;
                dbInfo[int.Parse(id)].EmergencyPhone = info.EmergencyPhone;
                db.SaveChanges();
                return RedirectToAction("StudentList_Complete");
            }
            catch
            {
                ViewData["Message"] = "修改出錯了唷!";
                return View("Details");
            }


        }

        #endregion "Details"
    }



}