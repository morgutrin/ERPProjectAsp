using ERPProject.Entity;
using ERPProject.Persistance;
using ERPProject.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ERPProject.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles;
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _context.Warehouses;
        }

        public IEnumerable<ArticleGroup> GetArticleGroups()
        {
            return _context.ArticleGroups;
        }

        public void AddArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void DecreaseAmount(int articleId, int amountToDecrease)
        {
            var article = _context.Articles.Single(x => x.Id.Equals(articleId));
            if (article.Amount - amountToDecrease < 0)
            {
                throw new AmountLessThanZeroException("Article amount cannot be less than 0");
            }
            article.Amount -= amountToDecrease;
            _context.SaveChanges();
        }

        public void IncreaseAmount(int articleId, int amountToIncrease)
        {
            var article = _context.Articles.Single(x => x.Id.Equals(articleId));
            article.Amount += amountToIncrease;
            _context.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            _context.Articles.Remove(GetArticle(id));
            _context.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.Single(x => x.Id.Equals(id));
        }
    }
}