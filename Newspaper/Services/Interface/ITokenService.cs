using Newspaper.Models;

namespace Newspaper.Services.Interface
{
    public interface ITokenService
    {
        public string CreateRefeshToken();
        public string CreateAccessToken(User user);
    }
}
