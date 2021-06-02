// <copyright file="ISiteService.cs" company="Portable">
// Copyright (c) Portable. All rights reserved.
// </copyright>
using ServiceLayer.DTO;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    /// <summary>
    /// Interface ISiteFactoryService
    /// </summary>
    public interface ISiteFactoryService
    {
        /// <summary>
        /// Get Site News
        /// </summary>
        /// <param name="filterDTO">Object of FilterDTO</param>
        /// <returns>Collection of NewsData</returns>
        Task<List<NewsData>> GetSiteNews(FilterDTO filterDTO);
    }
}