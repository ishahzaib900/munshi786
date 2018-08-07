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
        MunshiDBContext db = new MunshiDBContext();
        public ActionResult AddProperty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProperty(Property p)
        {

            //var m = PropertyController.GetMonthDifference(p.contract_start_date, p.contract_end_date);

            p.rent = Convert.ToDecimal(Request["rent"]);
            p.commission = Convert.ToDecimal(Request["commission"]);
            p.no_beds = Convert.ToInt32(Request["beds"]);
            p.no_cheques = Convert.ToInt32(Request["cheques"]);
            p.deposite = Convert.ToDecimal(Request["deposite"]);

            if (ModelState.IsValid)
            {
                db.Properties.Add(p);
                db.SaveChanges();
            }

            return RedirectToAction("AddProperty");
        }

        public ActionResult ListProperty()
        {
            return View(db.Properties.ToList());
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

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = Math.Abs(12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month);
            return monthsApart;
        }

    }
}