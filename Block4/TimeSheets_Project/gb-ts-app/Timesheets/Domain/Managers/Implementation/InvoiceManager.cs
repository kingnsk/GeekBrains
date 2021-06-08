using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        //private readonly ISheetRepo _sheetRepo;
        private readonly IInvoiceRepo _invoiceRepo;
        //private const int Rate = 100;
        private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;

        public InvoiceManager(IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
         //   _sheetRepo = sheetRepo;
        }

        public async Task<Guid> Create(InvoiceRequest request)
        {
            ////var sheets = await _invoiceAggregateRepo
            ////    .GetSheets(request.ContractId, request.DateStart, request.DateEnd);

            var invoice = InvoiceAggregate.Create(request.ContractId, request.DateEnd, request.DateStart);

            var sheetsToInclude = await _invoiceAggregateRepo
                .GetSheets(request.ContractId, request.DateStart, request.DateEnd);

            invoice.IcludeSheets(sheetsToInclude);

            await _invoiceRepo.Add(invoice);

            return invoice.Id;
        }
    }
}
