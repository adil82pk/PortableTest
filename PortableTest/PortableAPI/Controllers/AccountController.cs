namespace JWTAuthenticationExample.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using AutoMapper;
    using Common.Models;
    using ServiceLayer.Models;
    using Common.Constants;
    using ServiceLayer.Interface;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class AccountController
    /// </summary>
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IJWTToken jwtToken;
        private readonly IMapper mapper;

        // TODO: Should be in Database but just for the test hard coding it.
        private UserDTO userDTO = new UserDTO() { Id = 1, UserName = "portable", Password = "test" };
       
        /// <summary>
        /// Constructor LoginController
        /// </summary>
        /// <param name="configuration">Dependency of Configuration</param>
        /// <param name="jwtToken">Dependency of JWTToken</param>
        /// <param name="mapper">Dependency of AutoMapper</param>
        public AccountController(IConfiguration configuration, IJWTToken jwtToken, IMapper mapper)
        {
            this.configuration = configuration;
            this.jwtToken = jwtToken;
            this.mapper = mapper;
        }

        /// <summary>
        /// Login user (username:portable, Password: test )
        /// </summary>
        /// <param name="login">object of UserModel</param>
        /// <returns>JWT token with expiry and user details</returns>
        /// <remarks>Requires username and password to generate a JWT token</remarks>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] UserDTO login)
        {
            IActionResult response = Unauthorized();

            if (login == null)
            {
                return BadRequest(new ExceptionDetails
                {
                    ErrorMessage = ErrorMessages.IncorrectCredentials,
                });
            }

            if (login.UserName.Equals(userDTO.UserName) && login.Password.Equals(userDTO.Password))
            {
                var tokenString = jwtToken.GenerateJWTToken(userDTO);
                response = Ok(new
                {
                    token = tokenString,
                    expires = DateTime.Now.AddMinutes(int.Parse(configuration["Jwt:ExpiryInMinutes"])),
                });
            }

            return response;
        }
   }
}