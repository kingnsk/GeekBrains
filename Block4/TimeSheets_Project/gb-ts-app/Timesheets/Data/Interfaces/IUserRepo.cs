using Timesheets.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
        Task CreateUser(User user);
        Task<IEnumerable<User>> GetItems();
       // Task Add(User user);
        Task<User> GetItem(Guid id);
        Task Update(User user);
    }
}