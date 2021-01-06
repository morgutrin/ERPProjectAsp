using ERPProject.Entity;
using ERPProject.Models.Order;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _oService;
        private readonly IContractorService _cService;
        private readonly IArticleService _aService;
        private readonly ILoginService _lService;
        public OrderController(IOrderService orderService, IContractorService contractorService, IArticleService articleService, ILoginService loginService)
        {
            _oService = orderService;
            _cService = contractorService;
            _aService = articleService;
            _lService = loginService;
        }
        // GET: Order
        public ActionResult Index()
        {

            var orders = _oService.GetOrders().Select(x => new OrderIndexModelView
            {
                Id = x.Id,
                Code = x.Code,
                ContractorName = x.Contractor.Name,
                CreationDate = x.CreationDate,
                EmployeeFullName = x.Employee.FullName,
                RealizationDate = x.RealizationDate,
                Status = x.Status
            }).ToList();

            return View(orders);
        }
        public ActionResult Edit(int id)
        {
            @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
            @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");

            var order = _oService.GetOrder(id);

            var orderRows = _oService.GetOrderRows(id);
            ViewBag.Rows = orderRows.Count();
            OrderEditModelView model = new OrderEditModelView
            {
                Code = order.Code,
                ContractorId = order.ContractorId,
                Id = order.Id,
                RealizationDate = order.RealizationDate,
                Status = order.Status,
                CreationDate = order.CreationDate,
                OrderRows = orderRows,
                EmployeeId = order.EmployeeId

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderEditModelView model, int[] ArticleId, int[] Amount, decimal[] Price)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    Code = model.Code,
                    ContractorId = model.ContractorId,
                    CreationDate = DateTime.Now,
                    EmployeeId = _lService.GetEmployeeId(User.Identity.Name),
                    RealizationDate = DateTime.Now,
                    Status = model.Status,
                    OrderRows = new List<OrderRow>()
                };

                for (int i = 0; i < ArticleId.Length; i++)
                {

                    OrderRow row = new OrderRow
                    {
                        ArticleId = ArticleId[i],
                        Amount = Amount[i],
                        Price = Price[i]
                    };
                    order.OrderRows.Add(row);
                }
                _oService.SaveOrder(order);


                var o = _oService.GetOrder(model.Id);
                _oService.UpdateOrder(o);
                return RedirectToAction("Index");
            }
            else
            {
                @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
                @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");
                return View(model);
            }
        }

        public ActionResult Create()
        {
            @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
            @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");

            OrderCreateModelView model = new OrderCreateModelView();
            model.Code = "ORD/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" +
                         DateTime.Now.Second + "/" + DateTime.Now.Millisecond;
            model.RealizationDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(OrderCreateModelView model, int[] articleSelect, int[] amount, decimal[] price)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    Code = model.Code,
                    ContractorId = model.ContractorId,
                    CreationDate = DateTime.Now,
                    EmployeeId = _lService.GetEmployeeId(User.Identity.Name),
                    RealizationDate = model.RealizationDate,
                    Status = Status.open,
                    OrderRows = new List<OrderRow>()
                };
                for (int i = 0; i < articleSelect.Length; i++)
                {

                    OrderRow row = new OrderRow
                    {
                        ArticleId = articleSelect[i],
                        Amount = amount[i],
                        Price = price[i]
                    };
                    order.OrderRows.Add(row);
                }
                _oService.SaveOrder(order);
                return RedirectToAction("Index");
            }
            else
            {
                @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
                @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");
                return View(model);
            }
        }
        public ActionResult Delete(int id)
        {
            _oService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
        public ActionResult CloseOrder(int id)
        {
            _oService.CloseOrder(id);
            return RedirectToAction("Index");
        }
        public ActionResult OpenOrder(int id)
        {
            _oService.OpenOrder(id);
            return RedirectToAction("Index");
        }
    }
}