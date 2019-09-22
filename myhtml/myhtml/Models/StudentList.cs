using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseModels;

namespace myhtml.Models
{
    public class StudentList:BaseModel
    {
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
    }
}