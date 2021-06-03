using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class SheetRepo : ISheetRepo
    {
        void IRepoBase<Sheet>.Add()
        {
            throw new NotImplementedException();
        }

        Sheet IRepoBase<Sheet>.GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Sheet> IRepoBase<Sheet>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Sheet>.Uplate()
        {
            throw new NotImplementedException();
        }
    }
}
