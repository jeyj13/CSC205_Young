using CSC205_Young.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSC205_Young.Controllers
{
    public class HomeController : Controller
    {
        new public List<Person> people;
        public List<Family> families;
        public HomeController()
        {
            families = new List<Family>
            {
                new Family() { id=0, familyname = "Madeira", address1 = "123 Hastings Dr", city = "Cranberry Township", state = "PA", zip = "16066", homephone = "7247797964" },
                new Family() { id=1, familyname = "Johns", address1 = "3200 College Ave", city = "Beaver Falls", state = "PA", zip = "15010", homephone = "7248461298" },
                new Family() { id=2, familyname = "Ellis", address1 = "1 Sycamore Hollow", city = "Pittsburgh", state = "PA", zip = "15212", homephone = "4122371212" },
                new Family() { id=3, familyname = "Braddock", address1 = "23 Livingstone Dr", city = "Monroeville", state = "PA", zip = "15010", homephone = "4123277486" }
            };
            people = new List<Person>
            {
                new Person() { id = 0, firstname = "G", middlename = "Scott", lastname = "Madeira", cell = "4124180163", relationship = "dad", familyId = 0 },
                new Person() { id = 1, firstname = "Jean" , middlename = "E" , lastname = "Madeira" , cell = "4125551122" , relationship = "mom" , familyId = 0 },
                new Person() { id = 2, firstname = "Nick" , middlename = "A" , lastname = "Madeira" , cell = "4125559988" , relationship = "son" , familyId = 0 },
                new Person() { id = 3, firstname = "John" , middlename = "M" , lastname = "Madeira" , cell = "4125551234" , relationship = "son" , familyId = 0 },
                new Person() { id = 4, firstname = "Chris" , middlename = "T" , lastname = "Madeira" , cell = "4125556758" , relationship = "son" , familyId = 0 },
                new Person() { id = 5, firstname = "Jimmy" , middlename = "J" , lastname = "Johns" , cell = "6075556758" , relationship = "dad" , familyId = 1 },
                new Person() { id = 6, firstname = "Stacey" , middlename = "H" , lastname = "Johns" , cell = "6075556757" , relationship = "mom" , familyId = 1 },
                new Person() { id = 7, firstname = "Ian" , middlename = "F" , lastname = "Johns" , cell = "6075552257" , relationship = "son" , familyId = 1 },
                new Person() { id = 8, firstname = "Avery" , middlename = "K" , lastname = "Johns" , cell = "6075534757" , relationship = "daughter" , familyId = 1 },
                new Person() { id = 9, firstname = "Roy" , middlename = "F" , lastname = "Ellis" , cell = "9035534757" , relationship = "dad" , familyId = 2 },
                new Person() { id = 10, firstname = "Michelle" , middlename = "" , lastname = "Ellis" , cell = "9035531947" , relationship = "mom" , familyId = 2 },
                new Person() { id = 11, firstname = "Bernie" , middlename = "S" , lastname = "Braddock" , cell = "8145534757" , relationship = "mom" , familyId = 3 },
                new Person() { id = 12, firstname = "Mark" , middlename = "P" , lastname = "Anderson" , cell = "3025534757" , relationship = "son" , familyId = 3 }
    };
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["familyList"] == null)
            {
                Session["familyList"] = families;
            }
            if (Session["peopleList"] == null)
            {
                Session["peopleList"] = people;
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}