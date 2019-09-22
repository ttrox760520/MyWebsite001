using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseModels;

namespace myhtml.Models
{
    public class MemberList : BaseModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Identity { get; set; }
        public string Memo { get; set; }
        public int RealMember { get; set; }
    }
}