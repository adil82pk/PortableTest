namespace PortableAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class ErrorController
    /// </summary>
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Returns Error of Development environment 
        /// </summary>
        /// <param name="webHostEnvironment">Object of WebHostEnvironment</param>
        /// <returns>Error Details</returns>
        [HttpPost]
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        /// <summary>
        /// Return Error other than of Development Environment
        /// </summary>
        /// <returns>Error details</returns>
        [HttpPost]
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var customDetail = new Dictionary<string, object>();
            customDetail.Add("ErrorMessage", context.Error.Message);

            // Errors can be stored in the db or 3rd party services like Rollbar, Application insight etc.     
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }
    }
}
