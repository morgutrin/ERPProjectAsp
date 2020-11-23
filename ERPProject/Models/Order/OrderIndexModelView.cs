using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Order
{
    public class OrderIndexModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ContractorName { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RealizationDate { get; set; }
        public Status Status { get; set; }
    }
}