using EmailSender;
using ERPProject.Entity;
using ERPProject.Models.Login;
using ERPProject.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ERPProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class LoginController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService, IEmployeeService employeeService)
        {
            _loginService = loginService;
            _employeeService = employeeService;
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginLoginModelView());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginLoginModelView view, string returnUrl)
        {
            var dataItem = _loginService.GetOperator(view.Login);
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Login, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }

        public ActionResult Index()
        {
            var model = _loginService.GetAll().Select(x => new LoginIndexModelView
            {
                Id = x.Id,
                EmployeeFullName = x.Employee.FullName,
                Login = x.Login,
                Roles = _loginService.GetEmployeeRolesString(x.EmployeeId)
            });
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new LoginCreateModelView { Roles = new List<SelectListItem>() };
            @ViewBag.Employees = new SelectList(_employeeService.GetAll(), "Id", "FullName");
            model.SelectedRoles = new[] { _loginService.GetRoles().Count };
            foreach (var role in _loginService.GetRoles())
            {
                model.Roles.Add(new SelectListItem { Text = role.Name, Value = role.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LoginCreateModelView model)
        {
            Operator oOperator = new Operator
            {
                EmployeeId = model.EmployeeId,
                Login = model.Login,
                Password = model.Password,
            };
            _loginService.OnOperatorCreated += new EmailSenderService().SendUserCredidentials;
            _loginService.CreateOperator(oOperator, model.SelectedRoles);

            return RedirectToAction("Index", "Login");

            // return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Delete(int id)
        {
            _loginService.DeleteOperator(id);
            return RedirectToAction("Index");
        }

        public JsonResult IsLoginExist(string login)
        {
            return Json(!_loginService.IsLoginExist(login), JsonRequestBehavior.AllowGet);
        }
    }
}