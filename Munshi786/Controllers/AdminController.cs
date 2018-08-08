using Munshi786.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Munshi786.Controllers
{
    public class AdminController : Controller
    {
        MunshiDBContext db = new MunshiDBContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users ouser)
        {            
            var LoggedUser=db.Users.Where(m => m.UserName == ouser.UserName && m.Password == ouser.Password).FirstOrDefault();
            if (LoggedUser != null)
            {
                Session["logged"]= LoggedUser;
                return RedirectToAction("Dashboard", "Admin");
            }
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