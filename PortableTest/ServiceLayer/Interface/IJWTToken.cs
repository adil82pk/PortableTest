using ServiceLayer.Models;

namespace ServiceLayer.Interface
{
    public interface IJWTToken
    {
        /// <summary>
        /// Generate Jwt Token
        /// </summary>
        /// <param name="userDTO">Object of UserDTO</param>
        /// <returns>Jwt Token</returns>
        string GenerateJWTToken(UserDTO userDTO);
    }
}
