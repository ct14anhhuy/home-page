﻿using HomePageVST.Controllers.Core;
using System.Web.Mvc;

namespace HomePageVST.Controllers
{
    public class OrganizationController : ControllerCore
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}