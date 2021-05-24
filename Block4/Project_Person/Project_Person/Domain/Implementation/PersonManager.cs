using Project_Person.Data;
using Project_Person.Domain.Interfaces;
using Project_Person.Models;
using Project_Person.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Person.Domain.Implementation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepo _personRepo;
        public PersonManager(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }
        public int Create(PersonRequest personRequest)
        {
            var person = new Person()
            {
                Age = personRequest.Age,
                Company = personRequest.Company,
                Email = personRequest.Email,
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Id = 0
            };
            var result = _personRepo.Add(person);
            return result;
        }

        public bool Delete(int id)
        {
            var result = _personRepo.Delete(id);
            return result;
        }

        public IEnumerable<Person> GetAll()
        {
            var result = _personRepo.GetItems();
            return result;
        }

        public Person GetByFullName(string firstName, string lastName)
        {
            var result = _personRepo.GetByFullName(firstName, lastName);
            return result;
        }

        public Person GetById(int id)
        {
            var result = _personRepo.GetItem(id);
            return result;
        }

        public IEnumerable<Person> GetPagination(int skip, int take)
        {
            var result = _personRepo.GetByPagination(skip, take);
            return result;
        }

        public bool Update(PersonRequest personRequest, int id)
        {
            var person = new Person()
            {
                Id = id,
                Age = personRequest.Age,
                Company = personRequest.Company,
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Email = personRequest.Email
            };
            var result = _personRepo.Update(person);
            return result;
        }
    }
}
