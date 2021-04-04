﻿using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }

    public class RamMetricDto
    {
        public int Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
