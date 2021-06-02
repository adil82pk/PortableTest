namespace ServiceLayer.Class
{
    using AutoMapper;
    using Common.Constants;
    using Common.Exceptions;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using RepositoryLayer.Interface;
    using ServiceLayer.DTO;
    using ServiceLayer.Helper;
    using ServiceLayer.Interface;
    using ServiceLayer.Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Class GuardianService
    /// </summary>
    public class GuardianService : ISiteFactoryService
    {
        private readonly IHttpClientRepository httpClientRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Constructor of GuardianService
        /// </summary>
        /// <param name="httpClientRepository">Dependency of HttpClientRepository</param>
        /// <param name="mapper">Dependency of Mapper</param>
        /// <param name="configuration">Dependency of  Configuration</param>
        public GuardianService(IHttpClientRepository httpClientRepository, IMapper mapper, IConfiguration configuration)
        {
            this.httpClientRepository = httpClientRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        
        /// <summary>
        /// Get paginated Site news
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsData>> GetSiteNews(FilterDTO filterDTO)
        {
            var siteAPI = this.configuration["site:GuardianAPI"];
            HttpResponseMessage httpResponseMessage = await this.httpClientRepository.GetAsync(siteAPI, ParameterHelper.ParseQueryParameters(filterDTO));
            Guardian siteNewsDTO = new Guardian();
            List<NewsData> newsDTO = new List<NewsData>();
            string body = string.Empty;

            if (httpResponseMessage == null)
            {
                throw new ServiceLayerException(ErrorMessages.HttpResponseError);
            }

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                httpResponseMessage.EnsureSuccessStatusCode();
                body = await httpResponseMessage.Content.ReadAsStringAsync();
                siteNewsDTO = JsonConvert.DeserializeObject<Guardian>(body);
                newsDTO = this.mapper.Map<List<NewsData>>(siteNewsDTO.Response.Results);
            }
            else
            {
                body = await httpResponseMessage.Content.ReadAsStringAsync();
                throw new ServiceLayerException(body);
            }

            return newsDTO;
        }
    }
}
