// <copyright file="SiteService.cs" company="Portable">
// Copyright (c) Portable. All rights reserved.
// </copyright>
namespace ServiceLayer.Class
{
    using RepositoryLayer.Interface;
    using ServiceLayer.Interface;
    using ServiceLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Exceptions;
    using Common.Constants;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class SiteFactoryService
    /// </summary>
    public class SiteFactoryService : ISiteFactoryService
    {
        private readonly IHttpClientRepository httpClientRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor SiteFactoryService
        /// </summary>
        /// <param name="httpClientRepository">Dependency of HttpClientRepository</param>
        /// <param name="mapper">Dependency of Mapper</param>
        /// <param name="configuration">Dependency of Configuration</param>
        public SiteFactoryService(IHttpClientRepository httpClientRepository, IMapper mapper, IConfiguration configuration)
        {
            this.httpClientRepository = httpClientRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        ///<inheritdoc/>
        public async Task<List<NewsData>> GetSiteNews(FilterDTO filterDTO)
        {
            List<NewsData> newsDatas = new List<NewsData>();
            foreach (var source in filterDTO.NewsPreferences)
            {
                Type type = Type.GetType($"ServiceLayer.Class.{source}");
                if (type != null)
                {
                    ISiteFactoryService siteService = Activator.CreateInstance(type, this.httpClientRepository, this.mapper, this.configuration) as ISiteFactoryService;
                    var response = await siteService.GetSiteNews(filterDTO);
                    newsDatas.AddRange(response);
                }
                else
                {
                    throw new ServiceLayerException(ErrorMessages.NewPerferenceNotFound);
                }
            }

            return newsDatas;
        }
    }
}
