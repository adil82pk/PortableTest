using AutoMapper;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Class
{
    /// <summary>
    /// Class PinArticleService
    /// </summary>
    public class PinArticleService: IPinArticleService
    {
        private readonly IPinArticleRepository pinArticleRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor PinArticleService
        /// </summary>
        /// <param name="pinArticleRepository">Dependency of PinArticleRepository</param>
        /// <param name="mapper">Dependency of Mapper</param>
        public PinArticleService(IPinArticleRepository pinArticleRepository, IMapper mapper)
        {
            this.pinArticleRepository = pinArticleRepository;
            this.mapper = mapper;
        }
        
        ///<inheritdoc/>
        public async Task PinArticle(int userId, List<PinArticleDTO> articleDTOs)
        {
            var articles = mapper.Map<List<PinArticle>>(articleDTOs);
            articles.Select(x => x.UserId = userId).ToList();
            await this.pinArticleRepository.PinArticles(articles);
        }

        ///<inheritdoc/>
        public async Task<List<PinArticleDTO>> GetPinnedArticles(int userId)
        {
            var pinnedArticles = await this.pinArticleRepository.GetPinArticles(userId);
            return this.mapper.Map<List<PinArticleDTO>>(pinnedArticles);
        }
    }
}
