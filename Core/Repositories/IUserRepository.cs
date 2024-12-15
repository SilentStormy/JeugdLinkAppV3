using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace JeugdLinkDAL.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserAsync(string email,string password);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);

    }
}
