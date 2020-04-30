using ERPProject.Entity;
using ERPProject.Models.Login;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ERPProject.Controllers
{
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
        public ActionResult Login()
        {

            return View(new LoginIndexModelView());
        }
        [HttpPost]

        public ActionResult Login(LoginIndexModelView view, string returnUrl)
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

        public ActionResult Create()
        {
            var model = new LoginCreateModelView();
            model.Roles = new List<SelectListItem>();
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
            _loginService.CreateOperator(oOperator, model.SelectedRoles);


            return RedirectToAction("Index", "Inventory");
        }
    }
}