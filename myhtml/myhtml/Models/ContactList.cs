using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseModels;

namespace myhtml.Models
{
    public class ContactList:BaseModel
    {
        public string Date { get; set; }
        public string ContactOne { get; set; }
        public string ContactTwo { get; set; }
        public string ContactThree { get; set; }
        public string ContactFour { get; set; }
        public string ContactFive { get; set; }
        public string ContactSix { get; set; }
        public string ContactSeven { get; set; }
        public string ContactEight { get; set; }
        public string SeeDate { get; set; }
    }
}