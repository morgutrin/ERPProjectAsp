
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Text;
namespace ERPProject.Entity
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string InventoryNumber { get; set; }
        public InventoryGroup InventoryGroup { get; set; }

    }
}
