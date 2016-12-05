using CSC205_Young.Models;
using CSC205_Young.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

namespace CSC205_Young.Controllers
{
    public class FamilyController : Controller
    {
        public List<Family> families;
        //List<Family> families;

          public FamilyController()
          {
            families = new List<Family>
            {
                new Family() { id=0, familyname = "Madeira", address1 = "123 Hastings Dr", city = "Cranberry Township", state = "PA", zip = "16066", homephone = "7247797964" },
                new Family() { id=1, familyname = "Johns", address1 = "3200 College Ave", city = "Beaver Falls", state = "PA", zip = "15010", homephone = "7248461298" },
                new Family() { id=2, familyname = "Ellis", address1 = "1 Sycamore Hollow", city = "Pittsburgh", state = "PA", zip = "15212", homephone = "4122371212" },
                new Family() { id=3, familyname = "Braddock", address1 = "23 Livingstone Dr", city = "Monroeville", state = "PA", zip = "15010", homephone = "4123277486" }
            };

          }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["familyList"] == null)
            {
                Session["familyList"] = families;
            }
        }
        // GET: Family
        public ActionResult Index()
        {
            // var families = new FamilyViewModel();
            //List<Family> f;

            //families.Families.Add(new Family() {id = 0, familyname = "test", address1 = "test", city = "test", state = "test", zip = "test", homephone = "test" });

            // families.Families = f;
            //families = f;
            if (Request.IsAuthenticated)
            {
                var f = (List<Family>)Session["familyList"];
                return View(f);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Family/Details/5
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                var fList = (List<Family>)Session["familyList"];
                var f = fList[id];
                return View(f);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Family/Create
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

        // POST: Family/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {

            if (Request.IsAuthenticated)
            {
                try
                {
                    families = (List<Family>)Session["familyList"];
                    Family newFamily = new Family()
                    {
                        id = families.Count(),
                        familyname = collection["familyname"],
                        address1 = collection["middlename"],
                        city = collection["lastname"],
                        state = collection["cell"],
                        zip = collection["relationship"],
                        homephone = collection["homephone"]

                    };

                    families = (List<Family>)Session["familyList"];
                    families.Add(newFamily);
                    Session["familyList"] = families;
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

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                var fList = (List<Family>)Session["familyList"];
                var f = fList[id];
                return View(f);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // TODO: Add update logic here
                    var fList = (List<Family>)Session["familyList"];


                    var f = fList[id];

                    Family newFamily = new Family()
                    {
                        id = id,
                        familyname = collection["familyname"],
                        address1 = collection["address1"],
                        city = collection["city"],
                        state = collection["state"],
                        zip = collection["zip"],
                        homephone = collection["homephone"]

                    };
                    fList.Where(x => x.id == id).First().familyname = collection["familyname"];
                    fList.Where(x => x.id == id).First().address1 = collection["address1"];
                    fList.Where(x => x.id == id).First().city = collection["city"];
                    fList.Where(x => x.id == id).First().state = collection["state"];
                    fList.Where(x => x.id == id).First().zip = collection["zip"];
                    fList.Where(x => x.id == id).First().homephone = collection["homephone"];
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

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {
                var fList = (List<Family>)Session["familyList"];
                var f = fList[id];
                return View(f);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Family/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    var fList = (List<Family>)Session["familyList"];
                    var pList = (List<Person>)Session["peopleList"];


                    

                    


                    var f = fList[id];
                    var p = pList[id];

                    Session["familyList"] = fList.Where(x => x.id != id).ToList();
                    Session["peopleList"] = pList.Where(x => x.familyId != id).ToList();
                    fList = (List<Family>)Session["familyList"];
                    pList = (List<Person>)Session["peopleList"];

                    for (int x = id; x < fList.Count(); x++)
                    {

                        if (fList[x] != null)
                            fList[x].id = x;
                    }
                    for(int x = 0; x <pList.Count(); x++)
                    {
                        if (pList[x] != null)
                            pList[x].id = x;
                    }
                    Session["familyList"] = fList;
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
