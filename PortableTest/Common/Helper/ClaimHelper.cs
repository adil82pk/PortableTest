namespace Common.Helper
{
    using System.Security.Claims;

    public static class ClaimHelper
    {
        /// <summary>
        /// Get claim from Token
        /// </summary>
        /// <param name="claimsIdentity">Object of ClaimsIdentity</param>
        /// <param name="property">Propery</param>
        /// <returns>Property.</returns>
        public static string GetClaim(ClaimsIdentity claimsIdentity, string property)
        {
            string value = null;

            if (claimsIdentity != null)
            {
                value = claimsIdentity.FindFirst(property).Value;
            }

            return value;
        }
    }
}
