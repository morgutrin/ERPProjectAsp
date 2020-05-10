using ERPProject.Entity;
using ERPProject.Models.Warehouse.ExternalReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    public class WarehouseController : Controller
    {
        public ActionResult ExternalReceiptIndex()
        {
            return View();
        }

        public ActionResult CreateExternalReceipt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExternalReceipt(ExternalReceiptCreateModelView model)
        {
            return View();
        }

    }
}