using ERPProject.Models.Warehouse.ExternalRelease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Warehouse
{
    public class ExternalReleaseIndexModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string OrderCode { get; set; }
        public string ContractorName { get; set; }

        public string EmployeeFullName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}