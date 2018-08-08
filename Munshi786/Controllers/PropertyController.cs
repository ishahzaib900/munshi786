using Munshi786.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddProperty(Property p, HttpPostedFileBase[] files)
        {
            Users oUser=(Users)Session["logged"];
            p.created_by = oUser.Id;
            p.created_date = DateTime.Now;
            if (files != null)
            {
                string path="";
                foreach (HttpPostedFileBase file in files)
                {
                    string picture = Path.GetFileName(file.FileName);
                     path = Path.Combine(Server.MapPath("~/Content/PropertyDox"), picture);
                    string[] paths = path.Split('.');
                    string time = DateTime.UtcNow.ToString();
                    time = time.Replace(" ", "-");
                    time = time.Replace(":", "-");
                    file.SaveAs(paths[0] + "-" + time + Path.GetExtension(file.FileName));
                }
                p.file=path;
            }

            var m = PropertyController.GetMonthDifference(p.contract_start_date, p.contract_end_date);
            //p.rent = Convert.ToDecimal(Request["rent"]);
            //p.commission = Convert.ToDecimal(Request["commission"]);
            //p.no_beds = Convert.ToInt32(Request["beds"]);
            //p.no_cheques = Convert.ToInt32(Request["cheques"]);
            //p.deposite = Convert.ToDecimal(Request["deposite"]);
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