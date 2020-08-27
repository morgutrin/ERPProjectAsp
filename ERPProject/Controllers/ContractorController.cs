using ERPProject.Entity;
using ERPProject.Models.Contractor;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    [Authorize(Roles = "warehouser, admin")]
    public class ContractorController : Controller
    {
        private readonly IContractorService cService;
        public ContractorController(IContractorService contractorService)
        {
            cService = contractorService;
        }
        // GET: Contractor
        public ActionResult Index()
        {
            var list = cService.GetAll().Select(contractor => new ContractorIndexViewModel()
            {
                Name = contractor.Name,
                Id = contractor.Id,
                Code = contractor.Code,
                PostCode = contractor.PostCode,
                Address = contractor.Address,
                Country = contractor.Country,
                City = contractor.City,
                CountrySign = contractor.CountrySign,
                TIN = contractor.TIN
            });
            return View(list.ToList());
        }

        public ActionResult Create()
        {
            return View(new ContractorCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contractor contractor = new Contractor
                {
                    Name = model.Name,
                    Code = model.Code,
                    CountrySign = model.CountrySign,
                    Country = model.Country,
                    City = model.City,
                    TIN = model.TIN,
                    PostCode = model.PostCode,
                    Address = model.Address

                };
                cService.Create(contractor);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {


            var model = cService.GetById(id);
            var cDetails = new ContractorDetailsViewModel
            {
                Name = model.Name,
                Code = model.Code,
                CountrySign = model.CountrySign,
                Country = model.Country,
                City = model.City,
                TIN = model.TIN,
                PostCode = model.PostCode,
                Address = model.Address
            };
            return View(cDetails);
        }

        public ActionResult Delete(int id)
        {
            cService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}