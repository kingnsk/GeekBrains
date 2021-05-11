using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL
{
    public class SQLConnectionSettings
    {
        public const string ConnectionString = @"Data Source=manager_metrics.db;Version=3;Pooling=True;Max Pool Size=100;Journal Mode=Persist;";
    }
}
