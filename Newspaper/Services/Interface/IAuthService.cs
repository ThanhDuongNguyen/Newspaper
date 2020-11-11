using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs.Input;
using Newspaper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Services.Interface
{
    public interface IAuthService
    {
        public Task<EnumStatusCode> Register(UserForCreate userForCreate);
    }
}
