using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebUI.Helper
{
    public static class JwtHelper
    {
        public static (string UserId, string Name, string Surname, List<string> Roles) GetUserInfoFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var userId = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            var name = jwtToken.Claims.First(claim => claim.Type == "name").Value;
            var surname = jwtToken.Claims.First(claim => claim.Type == "surname").Value;
            
            var roles = jwtToken.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();

            return (userId, name, surname, roles);
        }

        public static List<string> GetClaimValues(string token, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var claimValues = jwtToken.Claims
                .Where(c => c.Type == claimType)
                .Select(c => c.Value)
                .ToList();

            return claimValues;
        }

        public static string GetClaimValue(string token, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }
    }
}
