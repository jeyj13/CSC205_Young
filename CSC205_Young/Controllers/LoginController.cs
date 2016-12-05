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
        //private ILoginServices userService;
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
           
           //FormsAuthentication.SetAuthCookie("TestUser", false);
            //  return RedirectToAction("Index", "Home");
            return View();
            
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(Login model)
        {
           // bool isAuthenticated;
            try
            {
                accounts = (List<Login>)Session["accountList"];
                
               /* var user = accounts.Where(x => x.username == collection["username"]).ToList();
                var p = accounts.Where(x => x.password == collection["password"]).ToList();*/
                
                bool userClear;


                if (model.username == null || model.password == null)
                {
                    this.ModelState.AddModelError("", "Missing user input");
                    return View(model);
                }
                Login userAuth = accounts.Where(x => x.username == model.username && x.password == model.password).SingleOrDefault();

                if(userAuth == null)
                {
                    userClear = false;
                }
                else
                {
                    userClear = true;
                }

                bool isAuthenticated = userClear; 
                if (isAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(model.username, true);
                    
                  /*  if (!Roles.RoleExists("administrator"))
                        Roles.CreateRole("administrator");

                    if (userAuth.admin == true && Roles.IsUserInRole(userAuth.username, "administrator") != true)
                    {
                        Roles.AddUserToRole(userAuth.username, "administrator");
                    }
                    else
                    {

                    }*/
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Invalid username or password");
                    return View(model);
                }

                //FormsAuthentication.SetAuthCookie("user1", true);
                //return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
        // GET: Logout
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }

        //GET: Register
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            try
            {
                var aList = (List<Login>)Session["accountList"];

                Login newLogin = new Login()
                {
                    email = collection["email"],
                    username = collection["username"],
                    password = collection["password"],
                    name = collection["name"],
                    admin = false
                };

                aList.Add(newLogin);
                Session["accountList"] = aList;

                return RedirectToAction("Login");
            }
            catch
            {
                return View(collection);
            }
        }
    }
}