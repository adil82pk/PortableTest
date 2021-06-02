
namespace PortableAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceLayer.Models;
    using ServiceLayer.Interface;
    using System.Threading.Tasks;
    using Common.Exceptions;
    using Common.Models;
    using Microsoft.AspNetCore.Authorization;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class SiteController
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        private readonly ISiteFactoryService siteService;

        /// <summary>
        /// SiteController Constructor
        /// </summary>
        /// <param name="siteService">Dependency of SiteFactoryService</param>
        public SiteController(ISiteFactoryService siteService)
        {
            this.siteService = siteService;
        }

        /// <summary>
        /// Get Site News
        /// </summary>
        /// <param name="filterDTO">Object of FilterDTO</param>
        /// <returns>Collection of NewsData</returns>
        [HttpPost]
        [Route("get-site-news")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NewsData>))]
        public async Task<IActionResult> GetSiteNews([FromBody] FilterDTO filterDTO)
        {
            try
            {
                return Ok(await this.siteService.GetSiteNews(filterDTO));
            }
            catch (ServiceLayerException ex)
            {
                return BadRequest(new ExceptionDetails
                {
                    ErrorMessage = ex.Message,
                });
            }
        }
    }
}
