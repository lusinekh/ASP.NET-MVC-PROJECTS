using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcLogin.Models;

namespace MyMvcLogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult  Auterize(MyMvcLogin.Models.User usermodel)
        {
            using (LoginDateBase1Entities1 db=new LoginDateBase1Entities1())
            {
                var userDetalis = db.Users.Where(x => x.UserName == usermodel.UserName && x.Password == usermodel.Password).FirstOrDefault();

                if(userDetalis==null)
                {

                    usermodel.LoginErrorMessade = "Wrong userName and password";
                    return View("Index", usermodel);
                }
                else

                {

                    Session["IDUser"] = userDetalis.IDUser;
                    Session["UserName"] = userDetalis.UserName;
                    return RedirectToAction("Index", "Home");

                }


            }

               
        }
        public ActionResult LogOut()
        {
            int userId = (int)Session["IDUser"];
            Session.Abandon();
            return RedirectToAction("index", "Login");

        }


    }
}