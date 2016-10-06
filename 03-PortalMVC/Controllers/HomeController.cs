using _01_DAL.Classes;
using _01_DAL.DataModel;
using _03_PortalMVC.Code;
using _03_PortalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_PortalMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : WebAppController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    UserAccount dbUserAccount;

        //    using(var context = new Context())
        //    {
        //        dbUserAccount = 
        //    }
        //}
    }
}