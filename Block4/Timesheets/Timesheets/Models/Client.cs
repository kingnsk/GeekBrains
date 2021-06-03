using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Client
    {
        /// <summary> Информация о владельце контракта </summary>
        public Guid Id { get; set; }
        public Guid User { get; set; }
    }
}
