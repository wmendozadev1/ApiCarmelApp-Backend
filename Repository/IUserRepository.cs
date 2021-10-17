using APICarmel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Repository
{
    public interface IUserRepository
    {
        Task<string> Register(User user, string password);
        Task<string> Login(string userName, string password);
        Task<bool> UserExists(string username);
    }
}
