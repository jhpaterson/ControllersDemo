using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllersDemo.Models;

namespace ControllersDemo.Controllers
{
    public class OutputController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }

        public ActionResult Details()
        {
            ViewData["team"] = "Ferrari";
            ViewBag.Country = "Spain";
            TempData["points"] = 207;

            Person person = new Person
            {
                FirstName = "Fernando",
                LastName = "Alonso",
                DateOfBirth = DateTime.Parse("1981-07-29")
            };

            return View(person);
        }

        public ActionResult JsonAction()
        {
            Person person = new Person
            {
                FirstName = "Fernando",
                LastName = "Alonso",
                DateOfBirth = DateTime.Parse("1981-07-29")
            };
            return Json(person,JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectAction()
        {
            ViewData["team"] = "Ferrari";
            ViewBag.Country = "Spain";
            TempData["points"] = 207;

            return RedirectToAction("Temp", "Output");
        }

        public ActionResult Temp()
        {
            Person person = new Person
            {
                FirstName = "Fernando",
                LastName = "Alonso",
                DateOfBirth = DateTime.Parse("1981-07-29")
            };

            return View("Details",person);
        }

        public ActionResult RedirectRoute()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "About" });
        }

        public ActionResult RedirectUrl()
        {
            return Redirect("http://www.gcu.ac.uk");
        }

        public ActionResult UnauthorizedAction()
        {
            return new HttpUnauthorizedResult();
        }

        public ActionResult ServerErrorAction()
        {
            return new HttpStatusCodeResult(500, "Catastrophic server error!");
        }

    }
}
