using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using ERPProject.Entity;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ERPProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IEventService _eventService;
        public HomeController(ILoginService service, IEventService eService)
        {
            _loginService = service;
            _eventService = eService;
        }
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }


    }
}