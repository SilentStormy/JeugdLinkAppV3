using JeugdLinkBLL.Interfaces;

using Core.Entities;
using JeugdLinkDAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.UserService
{
    public class Registration : IRegistration
    {

        private readonly IUserRepository _userRepository;

        public Registration(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Register(User user)
        {
            if (await _userRepository.GetUserByEmailAsync(user.email) != null)
            {
                throw new Exception("User with this email already exists.");
            }
            return await _userRepository.CreateUserAsync(user);

        }

      
    }
}
