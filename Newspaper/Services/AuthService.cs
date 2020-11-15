using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Data.Interface;
using Newspaper.DTOs.Input;
using Newspaper.Helpers;
using Newspaper.Models;
using Newspaper.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Newspaper.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public AuthService(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<EnumStatusCode> Register(UserForCreate userForCreate)
        {
            //check email exist
            if (await _authRepository.IsEmailExist(userForCreate.Email))
                return EnumStatusCode.EmailExist;

            //map user get from register form to user and setup password hash, password salt
            var user = _mapper.Map<User>(userForCreate);
            user.PasswordSalt = Salt.Create();
            user.PasswordHash = Hash.Create(userForCreate.Password, user.PasswordSalt);
            user.RoleID = 1;

            _authRepository.CreateUser(user);
            await _authRepository.SaveChangeAsync();

            return EnumStatusCode.OK;
        }

        public async Task<User> IsLoginValid(LoginDTO loginDTO)
        {
            var user = await _authRepository.GetUser(loginDTO.Email);
            if (user == null || !Hash.Validate(loginDTO.Password, user.PasswordSalt, user.PasswordHash))
                return null;
            return user;
        }

        public async Task UpdateUser(User user)
        {
            _authRepository.Update(user);
            await _authRepository.SaveChangeAsync();
        }
    }
}
