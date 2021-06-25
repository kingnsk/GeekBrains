using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Xunit;
using Timesheets.Domain.ValueObjects;
using FluentAssertions;

namespace Timesheets.Tests
{
    public class InvoiceAggregateTests
    {
        public static int numberOfRandomSheets = 15;
        public static int rate = 150;
        public static Guid contractId = Guid.Parse("b8cd2b07-536f-4f28-94bd-60d9d2b88241");

        [Fact]
        public void IncludeSheetsTest()
        {
            var invoiceBuilder = new InvoiceAggregateBuilder();
            var sheetsBuilder = new SheetAggregateBuilder();
            var randomSheets = new List<Sheet>();

            for (int i = 0; i < numberOfRandomSheets; i++)
            {
                randomSheets.Add(sheetsBuilder.CreateRandomSheet());
            }

            var invoiceAggregate = invoiceBuilder.GetRandomInvoiceAggregate();
            invoiceAggregate.IncludeSheets(randomSheets);

            Money summOfSheets = Money.FromDecimal(numberOfRandomSheets * sheetsBuilder.AmountInRandomSheets * rate);

            invoiceAggregate.Sheets.Should().BeEquivalentTo(randomSheets);
            invoiceAggregate.Sum.Should().BeEquivalentTo(summOfSheets);
        }
    }
}
