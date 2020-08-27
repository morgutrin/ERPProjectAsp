using ERPProject.Entity;

namespace ERPProject.Models.Article
{
    public class ArticleCreateModelView
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Unit Unit { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int ArticleGroupId { get; set; }

        public int WarehouseId { get; set; }
    }
}