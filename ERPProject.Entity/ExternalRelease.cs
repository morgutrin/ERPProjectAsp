using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{

    public class ExternalRelease
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Code { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Employee")]
        public int CreatedById { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual ICollection<ExternalReleaseRow> ExternalReleaseRows { get; set; }

    }
}
