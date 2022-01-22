using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temp2.Controllers
{
    public class AuthController : Controller
    {
        private object viewModel;

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Login() {

            return View();
        }
        public ActionResult Test()
        {

            return View();
        }

        public ActionResult Tracking()
        {

            return View();
        }

        public ActionResult Products()
        {

            return View();
        }

        public ActionResult Feedback()
        {

            return View();
        }

        public ActionResult Seller()
        {

            return View();
        }




        public ActionResult Dosignup(string email, string password, string type)
        {

            int result = Models.User.signUp(email, password, type);
            if (result == 0)
            {
                return View("SignUp", (object)"User with that email already exists!");
            }
            else //useradded 
            {
                return RedirectToAction("Login.cshtml");
            }
        }

       /*public ActionResult getTrack(int orderid) {

            int result = Models.Track.doTrack(orderid);
            if (result==0)
            {
                
            }
            else { }
        
        }*/



    }
}