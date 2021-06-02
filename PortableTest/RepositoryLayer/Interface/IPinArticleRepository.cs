
namespace RepositoryLayer.Interface
{
    using RepositoryLayer.Context;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPinArticleRepository
    {
        /// <summary>
        /// Pin Articles
        /// </summary>
        /// <param name="articleDTOs">Collection of PinArticle</param>
        Task PinArticles(List<PinArticle> articleDTOs);

        /// <summary>
        /// Get Pin Articles
        /// </summary>
        /// <param name="userId">User identity</param>
        /// <returns>Collection of PinArticle</returns>
        Task<List<PinArticle>> GetPinArticles(int userId);
    }
}
