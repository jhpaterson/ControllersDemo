using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllersDemo.Models;

namespace ControllersDemo.Controllers
{
    public class InputController : Controller
    {
        //
        // GET: /Input/

        public ActionResult Index()
        {
            ViewBag.RouteData = GetString(RouteData.Values);
            ViewBag.QueryString = GetString(Request.QueryString);
            ViewBag.IDRoute = RouteData.Values["id"];
            ViewBag.ValueRoute = RouteData.Values["value"];
            ViewBag.IDQuery = Request.QueryString["id"];
            ViewBag.ValueQuery = Request.QueryString["value"];

            return View();
        }

        public ActionResult Params1(int? id, string value)
        {
            ViewBag.ID = id;
            ViewBag.Value = value;

            return View();
        }

        public ActionResult Params2(Person person)
        {
            return View(person);
        }

        public ActionResult Params3(int id = 0, string value = "val")
        {
            ViewBag.ID = id;
            ViewBag.Value = value;

            return View("Params1");
        }

        public ActionResult Params4(int id, string value)
        {
            ViewBag.ID = id;
            ViewBag.Value = value;

            return View("Params1");
        }

        private String GetString(IDictionary<string, object> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (KeyValuePair<string, object> kvp in dictionary)
            {
                if (!sb.ToString().Equals("{")) sb.Append(", ");
                sb.Append(String.Format("{0} = {1}", kvp.Key, kvp.Value));
            }
            sb.Append("}");
            return sb.ToString();
        }

        private String GetString(NameValueCollection nvc)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            for (int i = 0; i < nvc.Count; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(String.Format("{0} = {1}", nvc.GetKey(i), nvc.Get(i)));
            }
            sb.Append("}");
            return sb.ToString();
        }

    }
}
