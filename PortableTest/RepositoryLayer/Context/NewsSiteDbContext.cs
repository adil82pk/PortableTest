
namespace RepositoryLayer.Context
{
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Context;

    public class NewsSiteDbContext : DbContext
    {
        public NewsSiteDbContext() { }

        public NewsSiteDbContext(DbContextOptions<NewsSiteDbContext> options) : base(options)
        {
        }

        public DbSet<PinArticle> PinArticles { get; set; }
    }
}
