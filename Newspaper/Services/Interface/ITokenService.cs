using Newspaper.Models;
using System.Security.Claims;

namespace Newspaper.Services.Interface
{
    public interface ITokenService
    {
        public string CreateRefreshToken();
        public string CreateAccessToken(User user);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
