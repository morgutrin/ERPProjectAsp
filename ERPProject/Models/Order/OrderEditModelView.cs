using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Order
{
    public class OrderEditModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ContractorId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RealizationDate { get; set; }
        public Status Status { get; set; }
        public int EmployeeId { get; set; }

        public DateTime CreationDate { get; set; }
        [Display(Name = "OrderRows")]
        public IEnumerable<OrderRow> OrderRows { get; set; }
    }
}