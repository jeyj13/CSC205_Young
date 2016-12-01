using CSC205_Young.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CSC205_Young.Controllers
{
    public class LoginController : Controller
    {
        public List<Login> accounts;
        public LoginController()
        {
            accounts = new List<Login>
            {
                new Login() { email = "admin@this.a", username = "admin", password = "password", name = "Admin", admin = true  },
                new Login() { email = "user@basic.email", username = "user1", password = "user1", name = "Test User", admin = false } 

            };

        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["accountList"] == null)
            {
                Session["accountList"] = accounts;
            }
        }
        // GET: Login
        public ActionResult Login()
        {
           
           FormsAuthentication.SetAuthCookie("user", false);
            return View();
            
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(string username)
        {
            try
            {
               // accounts = (List<Login>)Session["accountList"];
                
                //var user = accounts.Where(x => x.username == collection["username"]).ToList();
               // var p = accounts.Where(x => x.password == collection["password"]).ToList();
                /*
                if (user == null || p == null)
                {
                    this.ModelState.AddModelError("", "Missing user input");
                    return View(collection);
                }
                bool isAuthenticated = this.userService.Authenticate(model.Username, model.Password);
                if (isAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    this.userService.EnableAdmin(model.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Invalid username or password");
                    return View(model);
                }
                */
                FormsAuthentication.SetAuthCookie("user1", true);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}