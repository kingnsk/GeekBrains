using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.InvoiceAggregate;

namespace Timesheets.Tests
{
    class InvoiceAggregateBuilder
    {
        public Guid contractId = Guid.Parse("b8cd2b07-536f-4f28-94bd-60d9d2b88241");
        public int periodOfDays = 20;

        public InvoiceAggregate GetRandomInvoiceAggregate()
        {
            var result = InvoiceAggregate.Create(contractId, DateTime.Now, DateTime.Now.AddDays(-periodOfDays));
            return result;
        }
    }
}
