using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    [Table("OrderRows")]
    public class OrderRow
    {
        [Key]
        public int Id { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

    }
}
