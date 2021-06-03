using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Sheet
    {
        /// <summary> Информация о затраченном времени сотрудника</summary>
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ContractId { get; set; }
        public Guid Service { get; set; }
        public int Amount { get; set }
    }
}
