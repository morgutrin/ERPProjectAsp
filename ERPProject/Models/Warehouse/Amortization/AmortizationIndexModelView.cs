using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Warehouse.Amortization
{
    public class AmortizationIndexModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Reason { get; set; }
    }
}