using EmailSender;
using ERPProject.Entity;
using ERPProject.Models.Employee;
using ERPProject.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
namespace ERPProject.Controllers
{
    [Authorize(Roles = "admin")]
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
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);
                var employee = new Employee
                {
                    ImageUrl = path,
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
                _employeeService.OnEmployeeCreated += new EmailSenderService().SendWelcomeMail;

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
                BirthDate = model.BirthDate,
                DateJoined = model.DateJoined,
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
                string path = "";
                var employee = _employeeService.GetById(model.ID);
                if (model.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    path = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    model.ImageFile.SaveAs(fileName);
                    string pathy = "C:/Users/Racki Kamil/source/repos/ERPProject/ERPProject/Images/" + Url.Content(employee.ImageUrl.Substring(employee.ImageUrl.LastIndexOf("/", StringComparison.Ordinal) + 1));
                    System.Diagnostics.Debug.WriteLine(pathy);
                    System.IO.File.Delete(pathy);
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
                if (model.ImageFile != null)
                {
                    employee.ImageUrl = path;
                }



                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            TempData["empId"] = id;
            var model = _employeeService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            if (model.ImageUrl == null)
            {
                EmployeeDetailsViewModel detailsViewModel1 = new EmployeeDetailsViewModel()
                {
                    Id = model.Id,
                    ImagePath = "~/Images/brak.png",
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
                ViewBag.ImageUrl = "~/Images/brak.png";
                return View(detailsViewModel1);
            }

            EmployeeDetailsViewModel detailsViewModel = new EmployeeDetailsViewModel()
            {
                Id = model.Id,
                ImagePath = model.ImageUrl,
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
            ViewBag.ImageUrl = model.ImageUrl;
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
            ViewBag.EmpId = id;
            var inventories = _inventoryService.GetAll().Where(x => x.Employee.Id.Equals(id))
                .Select(x => new EmployeeInventoryViewModel
                {
                    Id = x.Id,
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