using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newspaper.Services.Interface
{
    public interface ITokenService
    {
        public string CreateRefeshToken();
        public string CreateAccessToken(IEnumerable<Claim> claims);
    }
}
