namespace ServiceLayer.Interface
{
    using ServiceLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface ISiteFactoryService
    /// </summary>
    public interface IPinArticleService
    {
        /// <summary>
        /// Pin articles
        /// </summary>
        /// <param name="userId">User identity</param>
        /// <param name="articleDTOs">Collection of PinArticleDTO</param>
        Task PinArticle(int userId, List<PinArticleDTO> articleDTOs);

        /// <summary>
        /// Get pinned articles
        /// </summary>
        /// <param name="userId">user identity</param>
        /// <returns>Collection of PinArticleDTO</returns>
        Task<List<PinArticleDTO>> GetPinnedArticles(int userId);
    }
}
