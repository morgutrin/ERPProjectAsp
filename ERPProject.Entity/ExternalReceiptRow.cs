using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class ExternalReceiptRow
    {
        [Key]
        public int Id { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        [ForeignKey("ExternalReceipt")]
        public int ExternalReceiptId { get; set; }
        public virtual ExternalReceipt ExternalReceipt { get; set; }
    }
}
