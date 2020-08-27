using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Article
{
    public class ArticleIndexModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Unit Unit { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string ArticleGroup { get; set; }
        public string WarehouseName { get; set; }
    }
}