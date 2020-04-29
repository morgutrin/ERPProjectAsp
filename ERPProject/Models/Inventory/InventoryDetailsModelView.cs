using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Models.Inventory
{
    public class InventoryDetailsModelView
    {
        public string EmployeeFullName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string InventoryNumber { get; set; }
        public InventoryGroup InventoryGroup { get; set; }
    }
}
