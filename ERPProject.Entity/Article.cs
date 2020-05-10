using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Unit Unit { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ArticleGroup")]
        public int ArticleGroupId { get; set; }
        public virtual ArticleGroup ArticleGroup { get; set; }
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }




    }
}
