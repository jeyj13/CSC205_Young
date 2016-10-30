using CSC205_Young.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC205_Young.ViewModels
{
    public class PersonViewModel
    {
        public virtual List<Person> peoplelist { get; set; }
    }
}