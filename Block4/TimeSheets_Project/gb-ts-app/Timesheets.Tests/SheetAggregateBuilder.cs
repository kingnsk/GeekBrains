using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.SheetAggregate;
using Timesheets.Models.Dto;

namespace Timesheets.Tests
{
    public class SheetAggregateBuilder
    {
        public Guid SheetContractId = Guid.Parse("b8cd2b07-536f-4f28-94bd-60d9d2b88241");
        public Guid SheetEmployeeId = Guid.Parse("079365ab-b1ba-46be-a8a9-5de0977cefc8");
        public Guid SheetServiceId = Guid.Parse("d5f80ead-ad82-44ac-8eef-ad01e842b42c");
        public int AmountInRandomSheets = 8;

        public SheetAggregate CreateRandomSheet()
        {
            var sheetRequest = new SheetRequest()
            {
                Amount = AmountInRandomSheets,
                ContractId = SheetContractId,
                Date = DateTime.Now,
                EmployeeId = SheetEmployeeId,
                ServiceId = SheetServiceId
            };

            var result = SheetAggregate.CreateFromSheetRequest(sheetRequest);

            return result;
        }
    }
}
