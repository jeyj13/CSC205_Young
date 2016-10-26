using CSC205_Young.Models;
using CSC205_Young.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CSC205_Young.Controllers
{
    public class FamilyController : Controller
    {
        //List<Family> families;
        
      /*  public FamilyController()
        {
            //var families = new FamilyViewModel;
            

        }*/
        
        // GET: Family
        public ActionResult Index()
        {
            var families = new FamilyViewModel();
            List<Family> f;
            f = new List<Family>
            {
                new Family() {id = 0, familyname = "test", address1 = "test", city = "test", state = "test", zip = "test", homephone = "test" }
            };
            // families.Families.Add(new Family() {id = 0, familyname = "test", address1 = "test", city = "test", state = "test", zip = "test", homephone = "test" });

            families.Families = f;
            return View(families);
        }

        // GET: Family/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Family/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Family/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Family/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
