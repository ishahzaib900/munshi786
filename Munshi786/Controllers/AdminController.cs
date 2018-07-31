using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Munshi786.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        #region Expence
        public ActionResult AddExpence()
        {
            return View();
        }
        #endregion      
    }
}