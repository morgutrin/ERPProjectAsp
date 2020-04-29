using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Models.Inventory
{
    public class InventoryCreateModelView
    {


        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string InventoryNumber { get; set; }
        public InventoryGroup InventoryGroup { get; set; }
    }
}
