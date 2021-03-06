﻿using Munshi786.Models;
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


        #region Property
        public ActionResult AddProperty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProperty(Property p, HttpPostedFileBase[] files)
        {
            //Users oUser=(Users)Session["logged"];
            //p.created_by = oUser.Id;
            p.created_by = 1;
            p.created_date = DateTime.Now;
            p.owner_id = 1;
            //if (files != null)
            //{
            //    string path="";
            //    foreach (HttpPostedFileBase file in files)
            //    {
            //        string picture = Path.GetFileName(file.FileName);
            //         path = Path.Combine(Server.MapPath("~/Content/PropertyDox"), picture);
            //        string[] paths = path.Split('.');
            //        string time = DateTime.UtcNow.ToString();
            //        time = time.Replace(" ", "-");
            //        time = time.Replace(":", "-");
            //        file.SaveAs(paths[0] + "-" + time + Path.GetExtension(file.FileName));
            //    }
            //    p.file=path;
            //}


            //p.rent = Convert.ToDecimal(Request["rent"]);
            //p.commission = Convert.ToDecimal(Request["commission"]);
            //p.no_beds = Convert.ToInt32(Request["beds"]);
            //p.no_cheques = Convert.ToInt32(Request["cheques"]);
            //p.deposite = Convert.ToDecimal(Request["deposite"]);
            if (ModelState.IsValid)
            {
                db.Properties.Add(p);
                db.SaveChanges();
                int? propertyId = p.id;

                var m = PropertyController.GetMonthDifference(p.contract_start_date, p.contract_end_date);
                int m_diff = Convert.ToInt32(m / p.no_cheques);
                decimal cheque_Amount = p.rent / p.no_cheques;
                DateTime dateStart = p.contract_start_date;
                ChequeDetail cd;
                Random rand = new Random();
                for (int i = 0; i < p.no_cheques; i++)
                {
                    cd = new ChequeDetail()
                    {
                        cheque_amount = cheque_Amount,
                        cheque_date = dateStart,
                        cheque_till = dateStart.AddMonths(m_diff),
                        cheque_by_id = 2,
                        appartment_id = propertyId,
                        cheque_no = rand.Next()
                    };
                    var added = new ChequeDetailsController().AddCheque(cd);
                    //if (added == false)
                    //{
                    //    new ChequeDetailsController().DelAllPropCheques(propId);
                    //    this.DeleteProperty(propId);
                    //    break;
                    //}
                    dateStart = dateStart.AddMonths(m_diff);
                }
            }
            return RedirectToAction("AddProperty");
        }


        public ActionResult ListProperty()
        {
            var list = db.Properties.ToList().OrderBy(m=>m.created_date);
            foreach(var item in list)
            {
                item.contract_renew = (item.contract_end_date - item.contract_start_date).Days;
            }
            return View(list);

        }

       
        public JsonResult GetPropertyById(int id)
        {
            bool found = true;
            Property p = db.Properties.Where(m => m.id == id).FirstOrDefault();

            if (p == null )
            {
                found = false;
            }
            return Json( new { data = p, found = found} , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProperty(Property p)
        {
            bool updated = true;
            int? id = null;
            var existing =  db.Properties.Where(m => m.id == p.id).FirstOrDefault();
            if (existing == null)
                updated = false;
            else
            {
                var clist = db.ChequeDetails.Where(m => m.appartment_id == p.id).ToList();
                p.created_by = existing.created_by;
                p.created_date = existing.created_date;
                p.owner_id = existing.owner_id;
                p.id = null;

                db.Properties.Remove(existing);
                db.Properties.Add(p);
                db.SaveChanges();
                id = p.id;
                foreach (var c in clist)
                {
                    db.ChequeDetails.Remove(c);
                }
                db.SaveChanges();

                foreach (var c in clist)
                {
                    c.appartment_id = id;
                    db.ChequeDetails.Add(c);
                }
                db.SaveChanges();
            }
            return Json( new { newid = id , u = updated }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DelProperty(int id)
        {
            List<ChequeDetail> chequeList;
            Property p = db.Properties.Where(m => m.id == id).FirstOrDefault();
            if (p != null)
            {
                chequeList = db.ChequeDetails.Where(m => m.appartment_id == id).ToList<ChequeDetail>();
                if (chequeList.Count() > 0)
                {
                    foreach (var item in chequeList)
                    {
                        db.ChequeDetails.Remove(item);
                    }
                }
                db.Properties.Remove(p);
                db.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.DenyGet);
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = Math.Abs(12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month);
            return monthsApart;
        }
        #endregion


        #region Expence
        public ActionResult AddExpenseType()
        {
            if (Session["logged"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Admin");
        }
        [HttpPost]
        public ActionResult AddExpenseType(ExpenseType exp)
        {
            db.ExpenseTypes.Add(exp);
            db.SaveChanges();
            return RedirectToAction("AddExpenseType", "Property");
        }
        public ActionResult AddExpense()
        {
            if (Session["logged"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Admin");
        }
        [HttpPost]
        public ActionResult AddExpense(Expense exp)
        {
            if (Session["logged"] != null)
            {
                Users oUser = (Users)Session["logged"];
                exp.added_date = DateTime.Now;
                exp.added_by = oUser.Id;
                db.Expenses.Add(exp);
                db.SaveChanges();
                return RedirectToAction("AddExpense", "Property");
            }
            return View();
        }
        #endregion

    }
}