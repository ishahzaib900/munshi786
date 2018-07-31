using Munshi786.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Munshi786.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult AddProperty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProperty(Property p)
        {
            return View();
        }

        public ActionResult ListProperty()
        {
            return View();
        }

        public ActionResult AddExpenseType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExpenseType(ExpenseType exp)
        {
            return View();
        }

        public ActionResult ChequeDetails()
        {
            return View();
        }


    }
}