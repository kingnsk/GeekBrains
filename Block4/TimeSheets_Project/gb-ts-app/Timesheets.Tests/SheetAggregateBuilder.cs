using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.SheetAggregate;

namespace Timesheets.Tests
{
    public class SheetAggregateBuilder
    {
        public static SheetAggregate Create()
        {
            var result = SheetAgregate.CreaeFromSheetRequest();
        }
    }
}
