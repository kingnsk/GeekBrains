using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Aggregates.SheetAggregate
{
    public class SheetAggregate: Sheet
    {
        private SheetAggregate() { }

        public static SheetAggregate Create(int amount, Guid contractId, DateTime date, Guid employeeId, Guid serviceId)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                ContractId = contractId,
                Date = date,
                EmployeeId = employeeId,
                ServiceId = serviceId
            };
        }

        public static SheetAggregate CreateFromSheetRequest(SheetRequest sheetRequest)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = sheetRequest.Amount,
                ContractId = sheetRequest.ContractId,
                Date = sheetRequest.Date,
                EmployeeId = sheetRequest.EmployeeId,
                ServiceId = sheetRequest.ServiceId
            };

        }

        public void ApproveSheet()
        {
            IsApproved = true;
            ApprovedDate = DateTime.Now;
        }

        public void ChangeEmployee(Guid newEmployeeId)
        {
            EmployeeId = newEmployeeId;
        }
    }
}
