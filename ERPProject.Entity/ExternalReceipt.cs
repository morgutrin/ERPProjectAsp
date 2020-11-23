using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class ExternalReceipt
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<ExternalReceiptRow> ExternalReceiptRows { get; set; }
        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }
        public virtual Contractor Contractor { get; set; }

        [ForeignKey("Employee")]
        public virtual int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
