using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest invoiceRequest);
    }
}
