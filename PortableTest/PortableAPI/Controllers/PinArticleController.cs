namespace PortableAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceLayer.Models;
    using ServiceLayer.Interface;
    using System.Threading.Tasks;
    using Common.Exceptions;
    using Common.Models;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using Common.Helper;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    
    /// <summary>
    /// Class PinArticleController
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PinArticleController : ControllerBase
    {
        private readonly IPinArticleService pinArticleService;

        /// <summary>
        /// Constructor PinArticleController
        /// </summary>
        /// <param name="pinArticleService">Dependency of PinArticleService</param>
        public PinArticleController(IPinArticleService pinArticleService)
        {
            this.pinArticleService = pinArticleService;
        }

        /// <summary>
        /// Pin Site Articles
        /// </summary>
        /// <param name="articleDTOs">Collection of PinArticleDTOs</param>
        /// <returns>Http response Ok(200) if successful else Http error
        /// </returns>
        [HttpPost]
        [Route("pin-articles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PinArticles([FromBody] List<PinArticleDTO> articleDTOs)
        {
            try
            {
                int userId = int.Parse(ClaimHelper.GetClaim((ClaimsIdentity)HttpContext.User.Identity, "UserId"));
                await this.pinArticleService.PinArticle(userId, articleDTOs);
                return Ok();
            }
            catch (ServiceLayerException ex)
            {
                return BadRequest(new ExceptionDetails
                {
                    ErrorMessage = ex.Message,
                });
            }
        }

        /// <summary>
        /// Get Pin articles
        /// </summary>
        /// <returns>Collection of PinArticleDTO</returns>
        [HttpGet]
        [Route("get-pinned-articles/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PinArticleDTO>))]
        public async Task<IActionResult> GetPinArticles()
        {
            try
            {
                int userId = int.Parse(ClaimHelper.GetClaim((ClaimsIdentity)HttpContext.User.Identity, "UserId"));
                var pinnedArticles = await this.pinArticleService.GetPinnedArticles(userId);
                return Ok(pinnedArticles);
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