using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Employee
    {
        /// <summary> Инофрмация о сотруднике </summary>
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
