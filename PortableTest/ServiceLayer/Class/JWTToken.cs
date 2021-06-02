// <copyright file="JWTToken.cs" company="Portable">
// Copyright (c) Portable. All rights reserved.
// </copyright>
namespace ServiceLayer.Class
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Common.Exceptions;
    using Microsoft.IdentityModel.Tokens;
    using ServiceLayer.Models;
    using Microsoft.Extensions.Configuration;
    using ServiceLayer.Interface;
    using System.Security.Claims;

    public class JWTToken : IJWTToken
    {
        private readonly IConfiguration configuration;

        public JWTToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <param name="userDTO">object of user</param>
        /// <returns>JWT token</returns>
        public string GenerateJWTToken(UserDTO userDTO)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = null;
            string token = null;
            try
            {
                var claims = new[]
              {
                new Claim("UserId", userDTO.Id.ToString()),
                };

                jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(int.Parse(configuration["Jwt:ExpiryInMinutes"])),
                claims: claims,
                signingCredentials: credentials);

                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            catch (Exception ex)
            {
                throw new ServiceLayerException(ex.InnerException.StackTrace);
            }

            return token;
        }
    }
}
