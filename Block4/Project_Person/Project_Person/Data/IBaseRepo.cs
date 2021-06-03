using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Person.Data
{
    public interface IBaseRepo<T>
    {
        T GetItem(int id);
        IEnumerable<T> GetItems();
        int Add(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
