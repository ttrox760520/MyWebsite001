using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseModels;

namespace myhtml.Models
{
    public class MemberList : BaseModel
    {
        public string 帳號 { get; set; }
        public string 密碼 { get; set; }
        public string 暱稱 { get; set; }
        public string 身分 { get; set; }
        public string 描述 { get; set; }
        public int 是否正式會員 { get; set; }
    }
}