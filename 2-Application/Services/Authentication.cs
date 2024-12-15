using JeugdLinkBLL.Interfaces;
using Core.Entities;
using JeugdLinkDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.UserService
{
    public class Authentication : IAuthenticator
    {
        private readonly IUserRepository _userRepository;

        public Authentication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(string email,string password)
        {
            var user= await _userRepository.GetUserAsync(email, password);
            if (user == null)
            {
                throw new Exception("Invalid email or Password");
            }
            return user;
        }
    }
}
