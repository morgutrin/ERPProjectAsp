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
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
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
    }
}