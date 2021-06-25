using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.SheetAggregate;

namespace Timesheets.Domain.Aggregates.SheetAggregate
{
    public interface ISheetAggregateRepo
    {
        Task<SheetAggregate> GetItem(Guid id);
        Task<IEnumerable<SheetAggregate>> GetItems();
        Task Add(SheetAggregate item);
        Task Update(SheetAggregate item);
    }
}
