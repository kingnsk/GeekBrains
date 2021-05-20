using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
        void IRepoBase<User>.Add()
        {
            throw new NotImplementedException();
        }

        User IRepoBase<User>.GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IRepoBase<User>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<User>.Uplate()
        {
            throw new NotImplementedException();
        }
    }
}
