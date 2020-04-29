using ERPProject.Entity;
using ERPProject.Models.Employee;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly IEmployeeService _employeeService;
        private readonly IInventoryService _inventoryService;
        public EmployeeController(IInventoryService inventoryService, IEmployeeService employeeService)
        {

            _employeeService = employeeService;
            _inventoryService = inventoryService;
        }
        public ActionResult Index()
        {
            var employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                Address = employee.Address,
                DateJoined = employee.DateJoined,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                IsActive = employee.IsActive

            }).ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {

                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    BirthDate = model.BirthDate.Date,
                    DateJoined = model.DateJoined.Date,
                    Email = model.Email,
                    IdDocumentNo = model.IdDocumentNo,
                    PaymentMethod = model.PaymentMethod,
                    Address = model.Address,
                    City = model.City,
                    PostCode = model.PostCode,
                    IsActive = true


                };


                _employeeService.Create(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = _employeeService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var employee = new EmployeeEditViewModel()
            {
                ID = model.Id,
                EmployeeNo = model.EmployeeNo,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                LastName = model.LastName,
                Gender = model.Gender,
                Phone = model.Phone,
                BirthDate = model.BirthDate.Date,
                DateJoined = model.DateJoined.Date,
                Email = model.Email,
                IdDocumentNo = model.IdDocumentNo,
                PaymentMethod = model.PaymentMethod,
                Address = model.Address,
                City = model.City,
                PostCode = model.PostCode
            };
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.ID);
                if (employee == null)
                {
                    return HttpNotFound();
                }

                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.SecondName = model.SecondName;
                employee.LastName = model.LastName;
                employee.Gender = model.Gender;
                employee.Phone = model.Phone;
                employee.BirthDate = model.BirthDate;
                employee.DateJoined = model.DateJoined;
                employee.Email = model.Email;
                employee.IdDocumentNo = model.IdDocumentNo;
                employee.PaymentMethod = model.PaymentMethod;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.PostCode = model.PostCode;
                employee.ImageUrl = employee.ImageUrl;
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            TempData["empId"] = id;
            var model = _employeeService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            EmployeeDetailsViewModel detailsViewModel = new EmployeeDetailsViewModel()
            {
                Id = model.Id,
                EmployeeNo = model.EmployeeNo,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                LastName = model.LastName,
                Gender = model.Gender,
                Phone = model.Phone,
                BirthDate = model.BirthDate,
                DateJoined = model.DateJoined,
                Email = model.Email,
                IdDocumentNo = model.IdDocumentNo,
                PaymentMethod = model.PaymentMethod,
                Address = model.Address,
                City = model.City,
                PostCode = model.PostCode
            };
            return View(detailsViewModel);
        }

        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            _employeeService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Hire(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            _employeeService.Hire(id);
            return RedirectToAction("Index");
        }

        public PartialViewResult ShowInventory()
        {
            var id = (int)TempData["empId"];
            var inventories = _inventoryService.GetAll().Where(x => x.Employee.Id.Equals(id))
                .Select(x => new EmployeeInventoryViewModel
                {
                    Code = x.Code,
                    Name = x.Name,
                    InventoryNumber = x.InventoryNumber,
                    InventoryGroup = x.InventoryGroup
                }).ToList();
            return PartialView("_EmployeeInventory", inventories);
        }

        public JsonResult IsEmailExist(string email)
        {
            return Json(!_employeeService.EmailExist(email), JsonRequestBehavior.AllowGet);
        }
    }
}