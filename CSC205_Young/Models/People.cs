﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC205_Young.Models
{
    public class Person
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string cell { get; set; }
        public string relationship { get; set; }
        public int familyId { get; set; }

    }
}