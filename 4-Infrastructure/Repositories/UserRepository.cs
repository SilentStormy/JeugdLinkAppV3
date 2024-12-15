using Core.Entities;
using JeugdLinkDAL.Data;
using JeugdLinkDAL.Repositories.Base;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
      
        private readonly ApplicationContext _dbcontext;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ApplicationContext jeugdLinkContext, ILogger<UserRepository> logger) :base(jeugdLinkContext)
        {
            _dbcontext = jeugdLinkContext;
            _logger = logger;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
                var passwordhasher = new PasswordHasher<User>();
                user.password = passwordhasher.HashPassword(user, user.password);
                await _dbcontext.users.AddAsync(user);
                await _dbcontext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a user");
                throw;
            }
        }
       

        public async Task<User> GetUserAsync(string email,string password)
        {
            var user = await _dbcontext.users.FirstOrDefaultAsync(u => u.email == email);
            if (user != null)
            {
                var passwordhasher=new PasswordHasher<User>();
                var result=passwordhasher.VerifyHashedPassword(user,user.password,password);
                return result==PasswordVerificationResult.Success?user:null;
            }
            return null;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbcontext.users.FirstOrDefaultAsync(u => u.email == email);
        }

      
    }
    


}

