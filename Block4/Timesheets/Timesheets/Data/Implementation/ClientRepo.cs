using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ClientRepo : IClientRepo
    {
        void IRepoBase<Client>.Add()
        {
            throw new NotImplementedException();
        }

        Client IRepoBase<Client>.GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Client> IRepoBase<Client>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Client>.Uplate()
        {
            throw new NotImplementedException();
        }
    }
}
