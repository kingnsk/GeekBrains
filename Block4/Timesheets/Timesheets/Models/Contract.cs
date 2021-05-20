using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    /// <summary> Информация о договоре с клиентом </summary>
    public class Contract
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Descrption { get; set; }
        public List<Service> Services { get; set; }
    }
}
