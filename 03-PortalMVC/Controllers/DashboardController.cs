using _01_DAL.Classes;
using _01_DAL.DataModel;
using _01_DAL.Dto;
using _03_PortalMVC.Code;
using _03_PortalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_PortalMVC.Controllers
{
    [Authorize]
    public class DashboardController : WebAppController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}