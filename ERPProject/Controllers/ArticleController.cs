using ERPProject.Entity;
using ERPProject.Models.Article;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    [Authorize(Roles = "warehouser, admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService service)
        {
            _articleService = service;
        }
        // GET: Article
        public ActionResult Index()
        {
            var articles = _articleService.GetAll().Select(x => new ArticleIndexModelView
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Amount = x.Amount,
                ArticleGroup = x.ArticleGroup.Name,
                Price = x.Price,
                Unit = x.Unit,
                WarehouseName = x.Warehouse.Name
            });
            return View(articles);
        }

        public ActionResult Create()
        {
            ViewBag.ArticleGroups = new SelectList(_articleService.GetArticleGroups(), "Id", "Name");
            ViewBag.Warehouses = new SelectList(_articleService.GetWarehouses(), "Id", "Name");
            return View(new ArticleCreateModelView());
        }
        [HttpPost]
        public ActionResult Create(ArticleCreateModelView model)
        {
            ViewBag.ArticleGroups = new SelectList(_articleService.GetArticleGroups(), "Id", "Name");
            ViewBag.Warehouses = new SelectList(_articleService.GetWarehouses(), "Id", "Name");
            if (ModelState.IsValid)
            {
                Article article = new Article
                {
                    Name = model.Name,
                    Code = model.Code,
                    Amount = model.Amount,
                    ArticleGroupId = model.ArticleGroupId,
                    Price = model.Price,
                    Unit = model.Unit,
                    WarehouseId = model.WarehouseId
                };
                _articleService.AddArticle(article);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _articleService.DeleteArticle(id);
            return RedirectToAction("Index");
        }
    }
}