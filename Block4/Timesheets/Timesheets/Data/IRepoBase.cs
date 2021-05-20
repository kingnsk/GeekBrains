using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Data
{
    public interface IRepoBase<T>
    {
        T GetItem(Guid Id);
        IEnumerable<T> GetItems();
        void Add();
        void Uplate();
    }
}
