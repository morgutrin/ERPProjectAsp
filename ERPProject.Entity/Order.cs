using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }
        public virtual Contractor Contractor { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RealizationDate { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }

    public enum Status
    {
        open,
        closed
    }
}
