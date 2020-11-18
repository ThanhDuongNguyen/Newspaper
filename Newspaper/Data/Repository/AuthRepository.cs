using Microsoft.EntityFrameworkCore;
using Newspaper.Data.Interface;
using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Data.Repository
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(NewspaperContext context) : base(context)
        {
        }

        public async Task<bool> IsEmailExist(string email)
        {
            if (await FindByCondition(user => user.Email == email).FirstOrDefaultAsync() == null)
                return false;
            return true;
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }


        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string email)
        {
            var user = await FindByCondition(user => user.Email == email).FirstOrDefaultAsync();
            if(user != null)
                await _context.Entry(user).Reference(x => x.Role).LoadAsync();
            return user;
        }
    }
}
