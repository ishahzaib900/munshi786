using Munshi786.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Munshi786.Controllers
{
    public class ChequeDetailsController : Controller
    {
        MunshiDBContext db = new MunshiDBContext();

        public bool AddCheque(ChequeDetail cd)
        {
            if (ModelState.IsValid)
            {
                int found = db.ChequeDetails.Count(m => m.cheque_no == cd.cheque_no);
                if (found == 0)
                {
                    db.ChequeDetails.Add(cd);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }


        public JsonResult GetPropertyCheques(int id)
        {
            var list = db.ChequeDetails.Where(m => m.appartment_id == id).OrderBy(m=>m.cheque_date);
            foreach(var item in list)
            {
                item.cheque_date_string = (item.cheque_date).ToString();
                item.cheque_till_string = (item.cheque_till).ToString();
            }
            string name = db.Users.Where(m=>m.Id==list.FirstOrDefault().cheque_by_id).FirstOrDefault().FirstName+" "+ db.Users.Where(m => m.Id == list.FirstOrDefault().cheque_by_id).FirstOrDefault().LastName;
            return Json(new { data = list, cheque_by = name},JsonRequestBehavior.AllowGet );
        }

    }
}