using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Models.Warehouse.ExternalRelease
{
    public class ExternalReleaseCreateModelView
    {
        public string Code { get; set; }
        public int OrderId { get; set; }

        public int ContractorId { get; set; }
        [Display()]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreationDate { get; set; }
    }
}