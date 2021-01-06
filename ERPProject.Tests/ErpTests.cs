using ERPProject.Controllers;
using ERPProject.Entity;
using ERPProject.Persistance;
using ERPProject.Services;
using ERPProject.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ERPProject.Tests
{
    [TestClass]
    public class ErpTests
    {
        private readonly IEmployeeService _employeeService;
        private readonly IInventoryService _inventoryService;
        private readonly ILoginService _loginService;
        private readonly IArticleService _articleService;
        private readonly ApplicationDbContext _context;
        public ErpTests()
        {
            _context = new ApplicationDbContext();
            _employeeService = new EmployeeService(_context);
            _articleService = new ArticleService(_context);
            _inventoryService = new InventoryService(_context);
            _loginService = new LoginService(_context);
        }
        [TestMethod]
        public void Create_GetValidEmployeeCreateView()
        {
            EmployeeController controller = new EmployeeController(_inventoryService, _employeeService);
            ViewResult viewResult = controller.Create() as ViewResult;

            Assert.AreEqual("", viewResult.ViewName);
        }
        [TestMethod]
        public void Create_GetValidArticleCreateView()
        {
            ArticleController controller = new ArticleController(_articleService);
            ViewResult viewResult = controller.Create() as ViewResult;

            Assert.AreEqual("", viewResult.ViewName);
        }


    }
}
