using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Warehouse.ExternalReceipt
{
    public class ExternalReceiptRowModel
    {
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ArticleId { get; set; }

    }
}
