﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class SQLConnectionSettings
    {
        public const string ConnectionString = @"Data Source=metrics.db;Version=3;Pooling=True;Max Pool Size=100;";
    }
}
