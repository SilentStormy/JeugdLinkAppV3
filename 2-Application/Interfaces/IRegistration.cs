using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeugdLinkDAL;
using Core.Entities;

namespace JeugdLinkBLL.Interfaces
{
    public interface IRegistration
    {
        Task<User> Register(User user);
    }
}
