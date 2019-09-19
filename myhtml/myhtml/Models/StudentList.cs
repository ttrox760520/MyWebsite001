using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseModels;

namespace myhtml.Models
{
    public class StudentList:BaseModel
    {
        public int Id { get; set; }
        public int 座號 { get; set; }
        public string 姓名 { get; set; }
        public string 暱稱 { get; set; }
        public string 電話 { get; set; }
        public string 地址 { get; set; }
        public string 緊急聯絡人 { get; set; }
        public string 緊急連絡人電話 { get; set; }
    }
}