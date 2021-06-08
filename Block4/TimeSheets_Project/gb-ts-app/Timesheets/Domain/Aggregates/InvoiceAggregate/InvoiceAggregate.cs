using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.ValueObjects;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregate: Invoice
    {
        private readonly decimal _rate = 150;

        private InvoiceAggregate() { }

        public static InvoiceAggregate Create(Guid contractId, DateTime dateEnd, DateTime dateStart)
        {
            return new InvoiceAggregate()
            {
                Id = Guid.NewGuid(),
                ContractId = contractId,
                DateEnd = dateEnd,
                DateStart = dateStart
            };
        }

        public void IcludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
            CalculateSum();
        }

        private void CalculateSum()
        {
            var amount = Sheets.Sum(x => x.Amount * _rate);
            Sum = Money.FromDecimal(amount);
        }
    }
}
