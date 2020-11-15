using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Data.Interface
{
    public interface IAuthRepository
    {
        public Task<bool> IsEmailExist(string email);
        public Task<User> GetUser(string email);
        public void CreateUser(User user);

        public void Update(User user);
        public Task<int> SaveChangeAsync();
    }
}
