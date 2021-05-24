using Project_Person.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Person.Data
{
    public interface IPersonRepo: IBaseRepo<Person>
    {
        Person GetByFullName(string firstName, string lastName);
        IEnumerable<Person> GetByPagination(int skip, int take);
    }
}
