// using System;
// using System.Collections.Generic;
// using Timesheets.Data.Interfaces;
// using Timesheets.Models;
//
// namespace Timesheets.Data.Implementation
// {
//     public class EmployeeRepo:IEmployeeRepo
//     {
//         public Employee GetItem(Guid id)
//         {
//             throw new NotImplementedException();
//         }
//
//         public IEnumerable<Employee> GetItems()
//         {
//             throw new NotImplementedException();
//         }
//
//         public void Add(Employee item)
//         {
//             throw new NotImplementedException();
//         }
//
//         public void Add()
//         {
//             throw new NotImplementedException();
//         }
//
//         public void Update()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly TimesheetDbContext _context;

        public EmployeeRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return
                await _context.Employees
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return
                await _context.Employees.ToListAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}