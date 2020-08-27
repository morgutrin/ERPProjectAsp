using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class ExternalReleaseRow
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("ExternalRelease")]
        public int ExternalReleaseId { get; set; }

        public virtual ExternalRelease ExternalRelease { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

    }
}
