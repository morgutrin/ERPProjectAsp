using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Warehouse.ExternalRelease
{
    public class ExternalReleaseDetailsModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ContractorName { get; set; }

        public string EmployeeFullName { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<ExternalReleaseRow> ExternalReleaseRows { get; set; }
    }
}