using CSC205_Young.Models;
using CSC205_Young.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSC205_Young.Controllers
{
    public class PeopleController : Controller
    {
        new public List<Person> people;
        public PeopleController(){
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
            if (Session["peopleList"] == null)
            {
                Session["peopleList"] = people;
            }
        }
    // GET: People
    public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var p = (List<Person>)Session["peopleList"];
                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            // var People = new PersonViewModel();
            // People.peoplelist = p;
            if (Request.IsAuthenticated)
            {
                var pList = (List<Person>)Session["peopleList"];
                var p = pList[id];


                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: People/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    people = (List<Person>)Session["peopleList"];
                    Person newPerson = new Person()
                    {
                        id = people.Count(),
                        firstname = collection["firstname"],
                        middlename = collection["middlename"],
                        lastname = collection["lastname"],
                        cell = collection["cell"],
                        relationship = collection["relationship"],
                        familyId = int.Parse(collection["familyId"]
                        )
                    };
                    people = (List<Person>)Session["peopleList"];
                    people.Add(newPerson);
                    Session["peopleList"] = people;

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                var pList = (List<Person>)Session["peopleList"];


                var p = pList[id];


                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add delete logic here
                    var pList = (List<Person>)Session["peopleList"];


                    var p = pList[id];

                    Person newPerson = new Person()
                    {
                        id = id,
                        firstname = collection["firstname"],
                        middlename = collection["middlename"],
                        lastname = collection["lastname"],
                        cell = collection["cell"],
                        relationship = collection["relationship"],
                        familyId = int.Parse(collection["familyId"]
                       )
                    };
                    pList.Where(x => x.id == id).First().firstname = collection["firstname"];
                    pList.Where(x => x.id == id).First().middlename = collection["middlename"];
                    pList.Where(x => x.id == id).First().lastname = collection["lastname"];
                    pList.Where(x => x.id == id).First().cell = collection["cell"];
                    pList.Where(x => x.id == id).First().relationship = collection["relationship"];
                    pList.Where(x => x.id == id).First().familyId = int.Parse(collection["familyId"]);
                    //Session["peopleList"] = pList.Where(x => x.id != id).ToList();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {

                //After first delete, it may throw out of range exception
                var pList = (List<Person>)Session["peopleList"];


                var p = pList[id];


                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add delete logic here
                    var pList = (List<Person>)Session["peopleList"];


                    var p = pList[id];

                    Session["peopleList"] = pList.Where(x => x.id != id).ToList();


                    pList = (List<Person>)Session["peopleList"];

                    for (int x = id; x < pList.Count(); x++)
                    {

                        if (pList[x] != null)
                            pList[x].id = x;
                    }
                    Session["peopleList"] = pList;
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
