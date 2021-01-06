using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Warehouse.Amortization
{
    public class AmortizationCreateModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime RealizationDate { get; set; }
        public string Reason { get; set; }
    }
}