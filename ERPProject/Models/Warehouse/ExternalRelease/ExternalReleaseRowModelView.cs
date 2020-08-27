using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Warehouse.ExternalRelease
{
    public class ExternalReleaseRowModelView
    {
        public int Id { get; set; }
        public Entity.Article Article { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}