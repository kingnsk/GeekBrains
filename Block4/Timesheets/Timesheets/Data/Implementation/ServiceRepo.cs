using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ServiceRepo : IServiceRepo
    {
        void IRepoBase<Service>.Add()
        {
            throw new NotImplementedException();
        }

        Service IRepoBase<Service>.GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Service> IRepoBase<Service>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Service>.Uplate()
        {
            throw new NotImplementedException();
        }
    }
}
