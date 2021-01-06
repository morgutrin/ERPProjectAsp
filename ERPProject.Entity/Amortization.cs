using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class Amortization
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Code { get; set; }
        public string Reason { get; set; }
        [ForeignKey("Employee")]
        public int CreatedById { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<AmortizationRow> AmortizationRows { get; set; }
    }
}
