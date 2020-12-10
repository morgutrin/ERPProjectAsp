using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPProject.Models.Inventory
{
    public class InventoryCreateModelView
    {


        public int EmployeeId { get; set; }
        [Remote("IsCodeExist", "Inventory", ErrorMessage = "Code exist in database.")]
        public string Code { get; set; }
        public string Name { get; set; }
        [Remote("IsInventoryNumberExist", "Inventory", ErrorMessage = "Inventory number exist in database.")]
        public string InventoryNumber { get; set; }
        public InventoryGroup InventoryGroup { get; set; }

    }
}
