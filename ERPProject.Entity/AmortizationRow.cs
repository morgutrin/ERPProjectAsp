using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class AmortizationRow
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("Amortization")]
        public int AmortizationId { get; set; }
        public virtual Amortization Amortization { get; set; }
        public int Amount { get; set; }
    }
}
