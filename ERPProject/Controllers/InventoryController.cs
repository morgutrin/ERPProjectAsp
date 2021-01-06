using ERPProject.Entity;
using ERPProject.Models.Inventory;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class InventoryController : Controller
    {
        // GET: Inventory

        private readonly IInventoryService _inventoryService;
        private readonly IEmployeeService _employeeService;

        public InventoryController(IInventoryService inventoryService, IEmployeeService employeeService)
        {

            _inventoryService = inventoryService;
            _employeeService = employeeService;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            Uri MyUrl = Request.UrlReferrer;
            var inventories = _inventoryService.GetAll().Select(x => new InventoryIndexModelView
            {
                Id = x.Id,
                Code = x.Code,
                EmployeeId = x.EmployeeId,
                EmployeeFullName = x.Employee.FullName,
                InventoryGroup = x.InventoryGroup,
                InventoryNumber = x.InventoryNumber,
                Name = x.Name
            }).ToList();

            return View(inventories);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            var inventory = _inventoryService.GetById(id);
            InventoryDetailsModelView model = new InventoryDetailsModelView
            {
                Name = inventory.Name,
                Code = inventory.Code,
                EmployeeFullName = inventory.Employee.FullName,
                InventoryGroup = inventory.InventoryGroup,
                InventoryNumber = inventory.InventoryNumber
            };
            return View(model);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            var model = new InventoryCreateModelView();
            @ViewBag.Employees = new SelectList(_employeeService.GetAll(), "Id", "FullName");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreateModelView model)
        {
            if (ModelState.IsValid)
            {
                var inventory = new Inventory
                {
                    EmployeeId = model.EmployeeId,
                    Name = model.Name,
                    Code = model.Code,
                    InventoryNumber = model.InventoryNumber,
                    InventoryGroup = model.InventoryGroup
                };
                _inventoryService.Create(inventory);

                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            @ViewBag.Employees = new SelectList(_employeeService.GetAll(), "Id", "FullName");
            var inventory = _inventoryService.GetById(id);
            InventoryEditModelView model = new InventoryEditModelView
            {
                Name = inventory.Name,
                Code = inventory.Code,
                EmployeeId = inventory.Employee.Id,
                InventoryGroup = inventory.InventoryGroup,
                InventoryNumber = inventory.InventoryNumber
            };
            return View(model);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InventoryEditModelView inventory)
        {

            if (ModelState.IsValid)
            {
                Inventory model = new Inventory
                {
                    Name = inventory.Name,
                    Code = inventory.Code,
                    EmployeeId = inventory.EmployeeId,
                    InventoryGroup = inventory.InventoryGroup,
                    InventoryNumber = inventory.InventoryNumber,
                    Id = inventory.Id
                };
                _inventoryService.Update(model);
                return RedirectToAction("Index");
            }

            return View();


        }

        public ActionResult Delete(int id)
        {
            _inventoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult IsCodeExist(string code)
        {
            return Json(!_inventoryService.IsCodeExist(code), JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsInventoryNumberExist(string inventoryNumber)
        {
            return Json(!_inventoryService.IsInventoryNumberExist(inventoryNumber), JsonRequestBehavior.AllowGet);
        }

    }
}