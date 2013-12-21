using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stream", "User");
            }
            else
            {
                return RedirectToAction("Index", "Post");
            }
            //return View();
        }

        //
        // GET: /Home/About

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        //
        // GET: /Home/Contact

        public ActionResult Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stream", "User");
            }
            else
            {
                return RedirectToAction("Index", "Post");
            }
            //ViewBag.Message = "Your contact page.";

            //return View();
        }

    }
}
