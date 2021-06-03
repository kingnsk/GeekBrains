using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ContactRepo : IContractRepo
    {
        void IRepoBase<Contract>.Add()
        {
            throw new NotImplementedException();
        }

        Contract IRepoBase<Contract>.GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contract> IRepoBase<Contract>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Contract>.Uplate()
        {
            throw new NotImplementedException();
        }
    }
}
