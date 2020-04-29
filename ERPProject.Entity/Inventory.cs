using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string InventoryNumber { get; set; }
        public InventoryGroup InventoryGroup { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
