namespace RepositoryLayer.Class
{
    using RepositoryLayer.Context;
    using RepositoryLayer.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class PinArticleRepository
    /// </summary>
    public class PinArticleRepository : IPinArticleRepository
    {
        private readonly NewsSiteDbContext newsSiteDbContext;

        public PinArticleRepository(NewsSiteDbContext newsSiteDbContext)
        {
            this.newsSiteDbContext = newsSiteDbContext;
        }

        public async Task PinArticles(List<PinArticle> articleDTOs)
        {
            if (articleDTOs.Count() > 0)
            {
                var userId = articleDTOs.First().UserId;
                foreach (var entity in this.newsSiteDbContext.PinArticles.Where(x => x.UserId == userId))
                {
                    this.newsSiteDbContext.PinArticles.Remove(entity);
                }

                foreach (var article in articleDTOs)
                {
                    await this.newsSiteDbContext.AddAsync(article);
                }

                await this.newsSiteDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PinArticle>> GetPinArticles(int userId)
        {
            List<PinArticle> pinArticles = new List<PinArticle>();
            if (userId > 0)
            {
                pinArticles = await this.newsSiteDbContext.PinArticles.Where(x => x.UserId == userId).ToListAsync();
            }
            return pinArticles;
        }
    }
}