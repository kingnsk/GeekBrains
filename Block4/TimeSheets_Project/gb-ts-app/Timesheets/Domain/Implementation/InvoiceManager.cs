using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly ISheetRepo _sheetRepo;
        private readonly IInvoiceRepo _invoiceRepo;
        private const int Rate = 100;

        public async Task<Guid> Create(InvoiceRequest invoiceRequest)
        {
            var sheets = await _sheetRepo
                .GetItemsForInvoice(invoiceRequest.ContractId, invoiceRequest.DateStart, invoiceRequest.DateEnd);

            var invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                ContractId = invoiceRequest.ContractId,
                DateEnd = invoiceRequest.DateEnd,
                DateStart = invoiceRequest.DateStart,
            };

            invoice.Sheets.AddRange(sheets);
            invoice.Sum = invoice.Sheets.Sum(x => x.Amount * Rate);

            await _invoiceRepo.Add(invoice);

            return invoice.Id;
        }
    }
}
