using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAll();
        IEnumerable<Warehouse> GetWarehouses();
        IEnumerable<ArticleGroup> GetArticleGroups();
        void AddArticle(Article article);
        void DecreaseAmount(int articleId, int amountToDecrease);
        void IncreaseAmount(int articleId, int amountToIncrease);
        void DeleteArticle(int id);
        Article GetArticle(int id);

    }
}
