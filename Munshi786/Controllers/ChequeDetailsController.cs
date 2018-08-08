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

    }
}