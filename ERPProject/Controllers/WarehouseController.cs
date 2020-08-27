using ERPProject.Entity;
using ERPProject.Models.Warehouse;
using ERPProject.Models.Warehouse.ExternalReceipt;
using ERPProject.Models.Warehouse.ExternalRelease;
using ERPProject.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    [Authorize(Roles = "warehouser, admin")]
    public class WarehouseController : Controller
    {
        private readonly IContractorService _cService;
        private readonly IArticleService _aService;
        private readonly IWarehouseService _wService;
        private readonly ILoginService _lService;

        public WarehouseController(IContractorService service, IArticleService aService, IWarehouseService wService, ILoginService lService)
        {
            _cService = service;
            _aService = aService;
            _wService = wService;
            _lService = lService;
        }

        public PartialViewResult GetEmployeeExternalReleases()
        {
            var list = _wService.GetEmployeeExternalReleases(_lService.GetEmployeeId(User.Identity.Name));
            var model = new ExternalReleaseEmployeeStats
            {
                Amount = list.Count()
            };
            return PartialView("_ExternalReleaseEmployeeAmount", model);

        }
        public ActionResult ExternalReceiptIndex()
        {
            var list = _wService.GetAll().Select(x => new ExternalReceiptIndexModelView
            {
                Id = x.Id,
                Code = x.Code,
                EmployeeFullName = x.Employee.FullName,
                ContractorName = x.Contractor.Name,
                CreationDate = x.CreationDate
            });
            return View(list.ToList());
        }
        public ActionResult ExternalReleaseIndex()
        {
            var list = _wService.GetAllExternalReleases().Select(x => new ExternalReleaseIndexModelView
            {
                Id = x.Id,
                Code = x.Code,
                EmployeeFullName = x.Employee.FullName,
                ContractorName = x.Contractor.Name,
                CreationDate = x.CreatedOn
            });
            return View(list.ToList());
        }
        public ActionResult CreateExternalReceipt()
        {
            @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
            @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");
            ExternalReceiptCreateModelView model = new ExternalReceiptCreateModelView();
            model.Code = "CER/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" +
                         DateTime.Now.Second + "/" + DateTime.Now.Millisecond;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateExternalReceipt(ExternalReceiptCreateModelView model, int[] articleSelect, [Required][RegularExpression(@"^[0-9]*$")] int[] amount, decimal[] price)
        {
            if (ModelState.IsValid)
            {
                ExternalReceipt externalReceipt = new ExternalReceipt
                {
                    Code = model.Code,
                    ContractorId = model.ContractorId,
                    CreationDate = DateTime.Now,
                    EmployeeId = _lService.GetEmployeeId(User.Identity.Name)
                };
                _wService.SaveExternalReceipt(externalReceipt);
                Thread.Sleep(1000);
                var receipt = _wService.GetExternalReceipt(model.Code);
                for (int i = 0; i < articleSelect.Length; i++)
                {
                    _aService.IncreaseAmount(articleSelect[i], amount[i]);
                    _wService.SaveExternalReceiptRows(new ExternalReceiptRow
                    {
                        Amount = amount[i],
                        Price = price[i],
                        ArticleId = articleSelect[i],
                        ExternalReceiptId = receipt.Id
                    });
                }

                return RedirectToAction("ExternalReceiptIndex");
            }

            @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
            @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");
            return View(model);
        }
        public ActionResult CreateExternalRelease()
        {
            @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
            @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");
            ExternalReleaseCreateModelView model = new ExternalReleaseCreateModelView();
            model.Code = "CERel/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" +
                         DateTime.Now.Second + "/" + DateTime.Now.Millisecond;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateExternalRelease(ExternalReleaseCreateModelView model, int[] articleSelect, int[] amount, decimal[] price)
        {
            if (ModelState.IsValid)
            {
                ExternalRelease externalRelease = new ExternalRelease
                {
                    Code = model.Code,
                    ContractorId = model.ContractorId,
                    CreatedOn = DateTime.Now,
                    CreatedById = _lService.GetEmployeeId(User.Identity.Name)
                };
                _wService.SaveExternalRelease(externalRelease);

                var release = _wService.GetExternalRelease(model.Code);
                for (int i = 0; i < articleSelect.Length; i++)
                {
                    _aService.DecreaseAmount(articleSelect[i], amount[i]);
                    _wService.SaveExternalReleaseRows(new ExternalReleaseRow
                    {
                        Amount = amount[i],
                        Price = price[i],
                        ArticleId = articleSelect[i],
                        ExternalReleaseId = release.Id
                    });
                }

                return RedirectToAction("ExternalReleaseIndex");
            }

            @ViewBag.Contractors = new SelectList(_cService.GetAll(), "Id", "Name");
            @ViewBag.Articles = new SelectList(_aService.GetAll(), "Id", "Name");
            return View(model);
        }

        public ActionResult ExternalReleaseDetails(int id)
        {
            var x = _wService.GetExternalRelease(id);
            var externalReleaseModel = new ExternalReleaseDetailsModelView
            {
                Id = x.Id,
                Code = x.Code,
                EmployeeFullName = x.Employee.FullName,
                ContractorName = x.Contractor.Name,
                CreationDate = x.CreatedOn,
                ExternalReleaseRows = _wService.GetExternalReleaseRows(x.Id)
            };
            return View(externalReleaseModel);
        }
        public ActionResult ExternalReceiptDetails(int id)
        {
            var x = _wService.GetExternalReceipt(id);
            var externalReleaseModel = new ExternalReceiptDetailsModelView
            {
                Id = x.Id,
                Code = x.Code,
                EmployeeFullName = x.Employee.FullName,
                ContractorName = x.Contractor.Name,
                CreationDate = x.CreationDate,
                ExternalReceiptRows = _wService.GetExternalReceiptRows(id)
            };
            return View(externalReleaseModel);
        }
        public ActionResult Delete(int id)
        {
            _wService.DeleteExternalRelease(id);
            return RedirectToAction("ExternalReleaseIndex");
        }
        [HttpPost]
        public JsonResult GetArticles()
        {
            var articles = _aService.GetAll().Select(x => new ArticlesDropDown
            {
                Id = x.Id,
                Name = x.Name
            });
            var articlesSelect = new SelectList(articles, "Id", "Name");
            return Json(articles);
        }

        public ActionResult DeleteExternalReceipt(int id)
        {
            _wService.DeleteExternalReceipt(id);
            return RedirectToAction("ExternalReceiptIndex");
        }
    }
}