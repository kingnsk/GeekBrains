using Timesheets.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Timesheets.Data.Interfaces
{
    public interface ISheetRepo: IRepoBase<Sheet>
    {
        Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStart, DateTime dateEnd);
    }
}