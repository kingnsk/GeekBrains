using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Controllers
{

    public class InvoicesController: TimesheetBaseController
    {
        private readonly IContractManager _contractManager;
        private readonly IInvoiceManager _invoiceManager;

        public InvoicesController(IContractManager contractManager, IInvoiceManager invoiceManager)
        {
            _contractManager = contractManager;
            _invoiceManager = invoiceManager;
        }

        /// <summary> Создает клиентский счет (invoice) </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest invoiceRequest)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(invoiceRequest.ContractId);

            if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {invoiceRequest.ContractId} is not active or not found.");
            }

            var id = await _invoiceManager.Create(invoiceRequest);
            return Ok(id);
        }

    }
}
