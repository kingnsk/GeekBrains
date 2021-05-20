using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        void IRepoBase<Employee>.Add()
        {
            throw new NotImplementedException();
        }

        Employee IRepoBase<Employee>.GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IRepoBase<Employee>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Employee>.Uplate()
        {
            throw new NotImplementedException();
        }
    }
}
