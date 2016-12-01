using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC205_Young.Models
{
    public class Login
    {
        public string email { get; set;}
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public bool admin { get; set; }
    }
}