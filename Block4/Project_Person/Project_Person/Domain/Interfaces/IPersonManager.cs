using Project_Person.Models;
using Project_Person.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Person.Domain.Interfaces
{
    public interface IPersonManager
    {
        public int Create(PersonRequest personRequest);
        public bool Update(PersonRequest personRequest, int id);
        public bool Delete(int id);
        public Person GetById(int id);
        public Person GetByFullName(string firstName, string lastName);
        public IEnumerable<Person> GetPagination(int skip, int take);
        public IEnumerable<Person> GetAll();
    }
}
